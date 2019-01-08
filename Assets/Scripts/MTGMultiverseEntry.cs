using System;
using System.Collections.Generic;

namespace MyBinder
{
    [Serializable]
    public class MTGMultiverseEntry
    {
        public string scryfallid;
        public Dictionary<LanguageMode, MTGLocalizedEntry> localizedEntries = new Dictionary<LanguageMode, MTGLocalizedEntry>();
    }
}
