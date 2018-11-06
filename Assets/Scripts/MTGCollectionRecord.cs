using System;
using System.Collections.Generic;

namespace MyBinder
{
    [Serializable]
    public class MTGCollectionRecord
    {
        public string oracleName;
        public Dictionary<string, MTGMultiverseEntry> entries = new Dictionary<string, MTGMultiverseEntry>();
    }
}
