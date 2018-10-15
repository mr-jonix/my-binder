namespace MyBinder
{

    public class CardFilter
    {
        public string name = string.Empty;
        public float convertedManaCost = -17f;
        public bool isWhite = false;
        public bool isBlue = false;
        public bool isBlack = false;
        public bool isRed = false;
        public bool isGreen = false;
        public bool isMulticolored = false;
        public bool isColorless = false;
        public bool isCreature = false;
        public bool isArtifact = false;
        public bool isInstant = false;
        public bool isSorcery = false;
        public bool isEnchantment = false;
        public bool isLand = false;
        public bool isPlaneswalker = false;
        public bool isTribal = false;
        public FilterMode filterMode = FilterMode.AND;

    }
}
