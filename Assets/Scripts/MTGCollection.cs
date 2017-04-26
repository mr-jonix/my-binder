using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MTGSingleLanguageEntry
{
    public string language;
    private uint regularCount;
    private uint foilCount;
    public string notes;

    public MTGSingleLanguageEntry()
    {
        language = "en";
        regularCount = 0;
        foilCount = 0;
        notes = string.Empty;
    }
}

public class MTGInventoryEntry
{
    public string multiverseId;
    public Dictionary<string, MTGSingleLanguageEntry> languageEntries;

    public MTGInventoryEntry(string mId)
    {
        multiverseId = mId;
        languageEntries = new Dictionary<string, MTGSingleLanguageEntry>();
        languageEntries.Add("en",new MTGSingleLanguageEntry());
    }
}

public class MTGCollection {

    public Dictionary<string, MTGInventoryEntry> inventory;

}
