using System.Collections.Generic;
using System;
[Serializable]
public class MTGCard
{
    public string artist;
    public float cmc;
    public List<string> colorIdentity;
    public List<string> colors;
    public string flavor;
    public List<ForeignCard> foreignNames;
    public int hand;
    public string id;
    public string imageName;
    public string layout;
    public int life;
    public int loyalty;
    public string manaCost;
    public string multiverseid;
    public string name;
    public List<string> names;
    public string number;
    public string originalText;
    public string originalType;
    public string power;
    public List<string> printings;
    public string rarity;
    public bool reserved;
    public string releaseDate;
    public string text;
    public bool timeshifted;
    public string toughness;
    public string type;
    public List<string> types;
    public string source;
    public bool starter;
    public List<string> subtypes;
    public List<string> supertypes;
    public List<int> variations;
    public string watermark;

    public bool ContainsForeign(string foreignName, bool onlyRussian)
    {
        if (onlyRussian)
        {
            foreach (ForeignCard f in foreignNames)
            {
                if (f.name.ToLower().Contains(foreignName) && f.language == "Russian")
                {
                    return true;
                }
            }
        }
        else
        {
            foreach (ForeignCard f in foreignNames)
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