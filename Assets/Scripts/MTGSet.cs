using System.Collections.Generic;
using System;

[Serializable]
public class MTGSet
{
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
