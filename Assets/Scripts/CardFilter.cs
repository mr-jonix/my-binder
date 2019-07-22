using System.Collections.Generic;

namespace MyBinder
{

    public class CardFilter
    {
        public string name = string.Empty;
        public List<string> setCodes = new List<string>();
        public float convertedManaCost = -17f;
        public bool isWhite = false;
        public bool isBlue = false;
        public bool isBlack = false;
        public bool isRed = false;
        public bool isGreen = false;
        public bool isMulticolored = false;
        public bool isMonocolored = false;
        public bool isColorless = false;
        public bool isCreature = false;
        public bool isArtifact = false;
        public bool isInstant = false;
        public bool isSorcery = false;
        public bool isEnchantment = false;
        public bool isLand = false;
        public bool isPlaneswalker = false;
        public bool isTribal = false;
        public bool isStandardLegal = false;
        public bool isModernLegal = false;
        public bool isLegacyLegal = false;
        public bool isVintageLegal = false;
        public FilterMode filterMode = FilterMode.AND;

    }
}
