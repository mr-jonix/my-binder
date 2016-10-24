using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

[Serializable]
public class SetLanguages
{
    public string de;
    public string fr;
    public string it;
    public string es;
    public string pt;
    public string jp;
    public string cn;
    public string tw;
    public string ru;
    public string ko;
}

[Serializable]
public class ForeignCard
{
    public string language;
    public string name;
    public int multiverseid;
}

[Serializable]
public class MTGSet {
    public string name;
    public string code;
    public string magicCardsInfoCode;
    public string releaseDate;
    public string border;
    public string type;
    public string block;
    public SetLanguages translations;
    public List<MTGCard> cards;
}

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

}