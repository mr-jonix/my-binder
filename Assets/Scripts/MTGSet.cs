using System.Collections.Generic;
using System;

[Serializable]
public class MTGSet : CardSet
{
    public int baseSetSize;
    public string block;
    public List<string> boosterV3;
    public string code;
    public MTGJSONMeta meta;
    public string mtgoCode;
    public bool isOnlineOnly = false;
    public string releaseDate;
    public int tcgplayerGroupId;
    public List<MTGToken> tokens;
    public string type;
    public int totalSetSize;
 }
