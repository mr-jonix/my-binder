using System;
using System.Collections.Generic;

namespace MyBinder
{
    [Serializable]
    public class MTGCollection
    {
        public Dictionary<string, MTGCollectionRecord> inventory = new Dictionary<string, MTGCollectionRecord>();

        public void UpdateQuantity(MTGCard _card, LanguageMode _languageMode, CardTreatment _treatment, int _amount)
        {
            var _name = _card.names.Count>1 ? _card.names[0] : _card.name;
            var _scryfallid = _card.scryfallId;
            MTGCollectionRecord _record = null;
            if (inventory.ContainsKey(_name))
            {
                inventory.TryGetValue(_name, out _record);
            }
            else
            {
                _record = new MTGCollectionRecord()
                {
                    oracleName = _name
                };
                inventory.Add(_name, _record);
            }

            MTGMultiverseEntry _entry = null;
            if (_record.entries.ContainsKey(_scryfallid))
            {
                _record.entries.TryGetValue(_scryfallid, out _entry);
            }
            else
            {
                _entry = new MTGMultiverseEntry()
                {
                    scryfallid = _scryfallid,
                    localizedEntries = new Dictionary<LanguageMode, MTGLocalizedEntry>()
                };
                _record.entries.Add(_scryfallid, _entry);
            }

            MTGLocalizedEntry _localizedEntry = null;
            if (_entry.localizedEntries.ContainsKey(_languageMode))
            {
                _entry.localizedEntries.TryGetValue(_languageMode, out _localizedEntry);
            }
            else
            {
                _localizedEntry = new MTGLocalizedEntry()
                {
                    language = _languageMode
                };
                _entry.localizedEntries.Add(_languageMode, _localizedEntry);
            }

            switch (_treatment)
            {
                case CardTreatment.REGULAR:
                    if (_card.hasNonFoil) _localizedEntry.regularQuantity += _amount;
                    if (_localizedEntry.regularQuantity < 0) _localizedEntry.regularQuantity = 0;
                    break;
                case CardTreatment.FOIL:
                    if (_card.hasFoil)
                    {
                        _localizedEntry.foilQuantity += _amount;
                    }

                    if (_localizedEntry.foilQuantity < 0)
                    {
                        _localizedEntry.foilQuantity = 0;
                    }

                    break;
                case CardTreatment.PROMO:
                    _localizedEntry.promoQuantity += _amount;
                    if (_localizedEntry.promoQuantity < 0) _localizedEntry.promoQuantity = 0;
                    break;
                default:
                    break;
            }
        }

        internal MTGQuantities RetrieveQuantities(MTGCard cardLink, LanguageMode languageMode)
        {
            var result = new MTGQuantities();
            var _name = cardLink.names.Count > 1 ? cardLink.names[0] : cardLink.name;

            if (inventory.ContainsKey(_name))
            {
                MTGCollectionRecord record = null;
                inventory.TryGetValue(_name, out record);
                foreach (var mEntry in record.entries)
                {
                    foreach (var lEntry in mEntry.Value.localizedEntries)
                    {
                        result.total += lEntry.Value.regularQuantity;
                        result.total += lEntry.Value.foilQuantity;
                        result.total += lEntry.Value.promoQuantity;
                        if (mEntry.Value.scryfallid == cardLink.scryfallId.ToString())
                        {
                            result.foilTotal += lEntry.Value.foilQuantity;
                            result.promoTotal += lEntry.Value.promoQuantity;
                            result.regularTotal += lEntry.Value.regularQuantity;
                            if (lEntry.Value.language == languageMode)
                            {
                                result.regularCurrentLanguage += lEntry.Value.regularQuantity;
                                result.foilCurrentLanguage += lEntry.Value.foilQuantity;
                                result.promoCurrentLanguage += lEntry.Value.promoQuantity;
                            }
                        }
                    }
                }
            }


            return result;
        }
    }
}