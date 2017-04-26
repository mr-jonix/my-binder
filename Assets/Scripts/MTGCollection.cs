using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class MTGSingleLanguageEntry
{
    public string language;
    public string multiverseId;
    private int regularCount;
    private int foilCount;
    public string notes;

    public MTGSingleLanguageEntry(string _language, string _multiverseId)
    {
        language = _language;
        multiverseId = _multiverseId;
        regularCount = 0;
        foilCount = 0;
        notes = string.Empty;
    }

    public MTGSingleLanguageEntry(string _multiverseId)
    {
        language = "English";
        multiverseId = _multiverseId;
        regularCount = 0;
        foilCount = 0;
        notes = string.Empty;
    }

    public void UpdateQuantity(bool _foil, int _amount)
    {
        if (!_foil)
        {
            regularCount += _amount;
        }
        else
        {
            foilCount += _amount;
        }

        if (regularCount < 0) regularCount = 0;
        if (foilCount < 0) foilCount = 0;
    }
}

[Serializable]
public class MTGInventoryEntry
{
    public string oracleName;

    public Dictionary<string, MTGSingleLanguageEntry> languageEntries;

    public MTGInventoryEntry(string _oracleName, string _multiverseId)
    {
        oracleName = _oracleName;
        languageEntries = new Dictionary<string, MTGSingleLanguageEntry>();
        languageEntries.Add("English", new MTGSingleLanguageEntry(_multiverseId));
    }

    public void UpdateQuantity(string _language, string _multiverseId, bool _foil, int _amount)
    {
        if (!languageEntries.ContainsKey(_language))
        {
            languageEntries.Add(_language, new MTGSingleLanguageEntry(_multiverseId));
        }

        languageEntries[_language].UpdateQuantity(_foil, _amount);

    }
}

[Serializable]
public class MTGCollection
{
    public Dictionary<string, MTGInventoryEntry> inventory;

    public void UpdateQuantity(MTGCard _card, string _language, bool _foil, int _amount)
    {
        if (_card != null)
        {
            if (!inventory.ContainsKey(_card.name))
            {
                inventory.Add(_card.name, new MTGInventoryEntry(_card.name, _card.multiverseid));
            }

            string foreignMID = _card.foreignNames.Find(x => x.language == _language).multiverseid;

            inventory[_card.name].UpdateQuantity(_language, foreignMID, _foil, _amount);
        }
    }

}
