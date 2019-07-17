using System;
using System.Collections.Generic;

namespace MyBinder
{
    public class IsWhiteSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _color = "W";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.colors.Contains(_color);
        }
    }

    public class IsBlueSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _color = "U";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.colors.Contains(_color);
        }
    }

    public class IsBlackSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _color = "B";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.colors.Contains(_color);
        }
    }

    public class IsRedSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _color = "R";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.colors.Contains(_color);
        }
    }

    public class IsGreenSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _color = "G";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.colors.Contains(_color);
        }
    }

    public class IsColorlessSpecification : CompositeSpecification<MTGCard>
    {
        public override bool IsSatisfiedBy(MTGCard entity)
        {
            return entity.colors.Count == 0;
        }
    }

    public class IsMulticoloredSpecification : CompositeSpecification<MTGCard>
    {
        public override bool IsSatisfiedBy(MTGCard entity)
        {
            return entity.colors.Count > 1;
        }
    }

    public class EnglishNameSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _text;

        public EnglishNameSpecification(string textToFind)
        {
            _text = textToFind.ToLower();
        }

        public override bool IsSatisfiedBy(MTGCard entity)
        {
            return entity.name.ToLower().Contains(_text);
        }
    }

    public class CMCSpecification : CompositeSpecification<MTGCard>
    {
        private readonly float _cmc;

        public CMCSpecification(float cmc)
        {
            _cmc = cmc;
        }

        public override bool IsSatisfiedBy(MTGCard entity)
        {
            if (_cmc == -17f)
            {
                return true;
            }
            return entity.convertedManaCost.Equals(_cmc)||entity.faceConvertedManaCost.Equals(_cmc);
        }
    }

    public class ForeignNameSpecification : CompositeSpecification<MTGCard>
    {
        private readonly ForeignDataObject _template;

        public ForeignNameSpecification(ForeignDataObject foreignCardTemplate)
        {
            _template = foreignCardTemplate;
        }

        public override bool IsSatisfiedBy(MTGCard entity)
        {
            foreach (ForeignDataObject foreignCard in entity.foreignData)
            {
                if (foreignCard.language == _template.language && foreignCard.name.ToLower().Contains(_template.name))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class CmcEqualsSpecification : CompositeSpecification<MTGCard>
    {
        private readonly int _cmc;

        public CmcEqualsSpecification(int cmcToCompareTo)
        {
            _cmc = cmcToCompareTo;
        }

        public override bool IsSatisfiedBy(MTGCard entity)
        {
            return entity.convertedManaCost == _cmc;
        }
    }

    public class IsCreatureSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _type = "Creature";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.types.Contains(_type);
        }
    }

    public class IsArtifactSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _type = "Artifact";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.types.Contains(_type);
        }
    }

    public class IsSorcerySpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _type = "Sorcery";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.types.Contains(_type);
        }
    }

    public class IsInstantSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _type = "Instant";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.types.Contains(_type);
        }
    }

    public class IsEnchantmentSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _type = "Enchantment";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.types.Contains(_type);
        }
    }

    public class IsPlaneswalkerSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _type = "Planeswalker";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.types.Contains(_type);
        }
    }

    public class IsTribalSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _type = "Tribal";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.types.Contains(_type);
        }
    }

    public class IsLandSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _type = "Land";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.types.Contains(_type);
        }
    }

    public class IsStandardLegalSpecification : CompositeSpecification<MTGCard>
    {
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.legalities.standard == "Legal";
        }
    }

    public class IsModernLegalSpecification : CompositeSpecification<MTGCard>
    {
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.legalities.modern == "Legal";
        }
    }

    public class IsLegacyLegalSpecification : CompositeSpecification<MTGCard>
    {
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.legalities.legacy == "Legal";
        }
    }

    public class IsVintageLegalSpecification : CompositeSpecification<MTGCard>
    {
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.legalities.vintage == "Legal" || card.legalities.vintage == "Restricted";
        }
    }

    public class IsInSetSpecification : CompositeSpecification<MTGCard>
    {
        private readonly List<string> setCodes;

        public IsInSetSpecification(List<string> codes)
        {
            setCodes = codes;
        }
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return setCodes.Contains(card.setCode);
        }
    }

    public class EmptySpecification : CompositeSpecification<MTGCard>
    {
        public override bool IsSatisfiedBy(MTGCard entity)
        {
            return false;
        }
    }

}