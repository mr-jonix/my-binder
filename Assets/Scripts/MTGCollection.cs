using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyBinder
{
    [Serializable]
    public class MTGCollection
    {
        public Dictionary<string, MTGCollectionRecord> inventory;

        public void UpdateQuantity(MTGCard _card, string _multiverseid, CardTreatment _treatment, int _amount)
        {
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
                    regularQuantity = 0,
                    foilQuantity = 0,
                    promoQuantity = 0
                };
                _record.entries.Add(_multiverseid, _entry);
            }

            switch (_treatment)
            {
                case CardTreatment.REGULAR:
                    _entry.regularQuantity += _amount;
                    if (_entry.regularQuantity < 0) _entry.regularQuantity = 0;
                    break;
                case CardTreatment.FOIL:
                    _entry.foilQuantity += _amount;
                    if (_entry.foilQuantity < 0) _entry.foilQuantity = 0;
                    break;
                case CardTreatment.PROMO:
                    _entry.promoQuantity += _amount;
                    if (_entry.promoQuantity < 0) _entry.promoQuantity = 0;
                    break;
                default:
                    break;
            }
        }

    }
}