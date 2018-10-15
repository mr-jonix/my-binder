using System.Collections.Generic;
using System;

[Serializable]
public class MTGSet : CardSet
{
    public string code;
    //public MTGJSONMeta meta;
    public string mtgoCode;
    public bool onlineOnly = false;
    public string releaseDate;
    public List<MTGToken> tokens;
    public string border;
    public string type;
    public string block;
    //public SetLanguages translations; - deprecated?

 }
