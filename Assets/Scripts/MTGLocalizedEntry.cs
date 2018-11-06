using System;

namespace MyBinder
{
    [Serializable]
    public class MTGLocalizedEntry
    {
        public LanguageMode language = LanguageMode.ENGLISH;
        public int regularQuantity = 0;
        public int foilQuantity = 0;
        public int promoQuantity = 0;
    }
}
