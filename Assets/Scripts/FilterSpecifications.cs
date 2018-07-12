using System;

namespace MyBinder
{
    public class IsWhiteSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _color = "White";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.colors.Contains(_color);
        }
    }

    public class IsBlueSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _color = "Blue";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.colors.Contains(_color);
        }
    }

    public class IsBlackSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _color = "Black";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.colors.Contains(_color);
        }
    }

    public class IsRedSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _color = "Red";
        public override bool IsSatisfiedBy(MTGCard card)
        {
            return card.colors.Contains(_color);
        }
    }

    public class IsGreenSpecification : CompositeSpecification<MTGCard>
    {
        private readonly string _color = "Green";
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
            return entity.cmc.Equals(_cmc);
        }
    }

    public class ForeignNameSpecification : CompositeSpecification<MTGCard>
    {
        private readonly ForeignCard _template;

        public ForeignNameSpecification(ForeignCard foreignCardTemplate)
        {
            _template = foreignCardTemplate;
        }

        public override bool IsSatisfiedBy(MTGCard entity)
        {
            foreach (ForeignCard foreignCard in entity.foreignNames)
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
            return entity.cmc == _cmc;
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

    public class EmptySpecification : CompositeSpecification<MTGCard>
    {
        public override bool IsSatisfiedBy(MTGCard entity)
        {
            return false;
        }
    }

}