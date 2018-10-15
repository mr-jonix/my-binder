using System.Collections.Generic;
using System;
[Serializable]
public class MTGCard: CardPrototype
{
    public float convertedManaCost;
    public string flavorText;
    public bool foilOnly=false;
    public List<ForeignCard> foreignData;
    public string frameVersion;
    public bool hasFoil=false;
    public bool hasNonFoil=false;
    public string layout = "normal";
    public MTGLegality legalities;
    public string manaCost;
    public int multiverseId;
    public List<string> names;
    public string originalText;
    public string originalType;
    public List<string> printings;
    public string rarity;
    public bool reserve = false;
    //public List<MTGRuling> rulings
    public List<string> subtypes;
    public List<string> supertypes;
    public List<string> types;
    public string setCode;


    public bool ContainsForeign(string foreignName, bool onlyRussian)
    {
        if (onlyRussian)
        {
            foreach (ForeignCard f in foreignData)
            {
                if (f.name.ToLower().Contains(foreignName) && f.language == "Russian")
                {
                    return true;
                }
            }
        }
        else
        {
            foreach (ForeignCard f in foreignData)
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