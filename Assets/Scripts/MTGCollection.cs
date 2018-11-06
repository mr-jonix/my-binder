using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyBinder
{
    [Serializable]
    public class MTGCollection
    {
        public Dictionary<string, MTGCollectionRecord> inventory = new Dictionary<string, MTGCollectionRecord>();

        public void UpdateQuantity(MTGCard _card, LanguageMode _languageMode, CardTreatment _treatment, int _amount)
        {
            var _multiverseid = _card.multiverseId.ToString();
            MTGCollectionRecord _record = null;
            if (inventory.ContainsKey(_card.name))
            {
                inventory.TryGetValue(_card.name, out _record);
            }
            else
            {
                _record = new MTGCollectionRecord()
                {
                    oracleName = _card.name
                };
                inventory.Add(_card.name, _record);
            }

            MTGMultiverseEntry _entry = null;
            if (_record.entries.ContainsKey(_multiverseid))
            {
                _record.entries.TryGetValue(_multiverseid, out _entry);
            }
            else
            {
                _entry = new MTGMultiverseEntry()
                {
                    multiverseId = _multiverseid,
                    localizedEntries = new Dictionary<LanguageMode, MTGLocalizedEntry>()
                };
                _record.entries.Add(_multiverseid, _entry);
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
                    _localizedEntry.regularQuantity += _amount;
                    if (_localizedEntry.regularQuantity < 0) _localizedEntry.regularQuantity = 0;
                    break;
                case CardTreatment.FOIL:
                    _localizedEntry.foilQuantity += _amount;
                    if (_localizedEntry.foilQuantity < 0) _localizedEntry.foilQuantity = 0;
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
            if (inventory.ContainsKey(cardLink.name))
            {
                MTGCollectionRecord record = null;
                inventory.TryGetValue(cardLink.name, out record);
                Debug.Log(record.oracleName);
                foreach (var mEntry in record.entries)
                {
                    foreach (var lEntry in mEntry.Value.localizedEntries)
                    {
                        result.total += lEntry.Value.regularQuantity;
                        result.total += lEntry.Value.foilQuantity;
                        result.total += lEntry.Value.promoQuantity;
                        if (mEntry.Value.multiverseId == cardLink.multiverseId.ToString())
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