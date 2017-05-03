using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MTGInventoryEntry
{
    public string oracleName;
    public string multiverseid;
    public int regularQuantity;
    public int foilQuantity;

    public MTGInventoryEntry(MTGCard _card, string _multiverseid)
    {
        oracleName = _card.name;
        multiverseid = _multiverseid;
        regularQuantity = 0;
        foilQuantity = 0;
    }
}

[Serializable]
public class MTGCollection
{
    public Dictionary<string, MTGInventoryEntry> inventory;

    public void UpdateQuantity(MTGCard _card, string _multiverseid, bool _foil, int _amount)
    {

    }

}
