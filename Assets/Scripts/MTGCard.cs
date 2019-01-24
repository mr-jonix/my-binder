using System.Collections.Generic;
using System;

[Serializable]
public class MTGCard: CardPrototype
{
    public float convertedManaCost;
    public string duelDeck;
    public float faceConvertedManaCost;
    public string flavorText;
    public List<ForeignDataObject> foreignData;
    public string frameEffect;
    public string frameVersion;
    public bool hasFoil = true;
    public bool hasNonFoil = true;
    public bool isAlternative = false;
    public bool isFoilOnly = false;
    public bool isOnlineOnly = false;
    public bool isOversized = false;
    public bool isReserved = false;
    public bool isTimeshifted = false;
    public string layout;
    public LegalityObject legalities;
    public string manaCost;
    public int multiverseId;
    public List<string> names;
    public string originalText;
    public string originalType;
    public List<string> printings;
    public string rarity;
    public List<RulingObject> rulings;
    public bool starter;
    public List<string> subtypes;
    public List<string> supertypes;
    public List<string> types;
    public List<string> variations;
    public string setCode;

    public bool ContainsForeign(string foreignName, bool onlyRussian)
    {
        if (onlyRussian)
        {
            foreach (ForeignDataObject f in foreignData)
            {
                if (f.name.ToLower().Contains(foreignName) && f.language == "Russian")
                {
                    return true;
                }
            }
        }
        else
        {
            foreach (ForeignDataObject f in foreignData)
            {
                if (f.name.ToLower().Contains(foreignName))
                {
                    return true;
                }
            }
        }
        return false;
    }
}