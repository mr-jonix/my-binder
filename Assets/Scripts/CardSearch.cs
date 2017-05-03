using System.Collections.Generic;
using System.Linq;

namespace MyBinder
{
    public static class CardSearch
    {
        static IEnumerable<T> CreateEmptyEnumerable<T>(IEnumerable<T> templateQuery)
        {
            return Enumerable.Empty<T>();
        }

        public static List<MTGCard> SimpleSearch(List<MTGCard> _cardCollection, string _cardName)
        {
            return _cardCollection.Where(x => x.name.ToLower().Contains(_cardName.ToLower())).ToList();
        }

        public static List<MTGCard> AdvancedSearch(List<MTGCard> _cardCollection, CardFilter _filter, bool onlyRussian)
        {
            var finalQuery = from card in _cardCollection
                             where card.name.ToLower().Contains(_filter.name.ToLower()) || card.ContainsForeign(_filter.name.ToLower(), onlyRussian)
                             select card;
            if (_filter.isWhite) finalQuery = finalQuery.Where(x => x.colors.Contains("White"));
            if (_filter.isBlue) finalQuery = finalQuery.Where(x => x.colors.Contains("Blue"));
            if (_filter.isBlack) finalQuery = finalQuery.Where(x => x.colors.Contains("Black"));
            if (_filter.isRed) finalQuery = finalQuery.Where(x => x.colors.Contains("Red"));
            if (_filter.isGreen) finalQuery = finalQuery.Where(x => x.colors.Contains("Green"));
            if (_filter.isColorless) finalQuery = finalQuery.Where(x => x.colors.Count == 0);
            if (_filter.isMulticolored) finalQuery = finalQuery.Where(x => x.colors.Count > 1);

            return finalQuery.ToList();
        }

        public static List<MTGCard> AdvancedSearchCP(List<MTGCard> _cardCollection, CardFilter _filter)
        {
            var englishName = new EnglishNameSpecification(_filter.name);
            var foreignCardTemplate = new ForeignCard() { name = _filter.name.ToLower(), language = "Russian" };
            var foreignName = new ForeignNameSpecification(foreignCardTemplate);
            var isWhite = new IsWhiteSpecification();
            var isBlue = new IsBlueSpecification();
            var isBlack = new IsBlackSpecification();
            var isRed = new IsRedSpecification();
            var isGreen = new IsGreenSpecification();
            var isColorless = new IsColorlessSpecification();
            var isMulticolored = new IsMulticoloredSpecification();
            var isCreature = new IsCreatureSpecification();
            var isArtifact = new IsArtifactSpecification();

            var resultingSpecification = englishName.Or(foreignName);

            switch (_filter.filterMode)
            {
                case FilterMode.AND:
                    {
                        if (_filter.isWhite) resultingSpecification = resultingSpecification.And(isWhite);
                        if (_filter.isBlue) resultingSpecification = resultingSpecification.And(isBlue);
                        if (_filter.isBlack) resultingSpecification = resultingSpecification.And(isBlack);
                        if (_filter.isRed) resultingSpecification = resultingSpecification.And(isRed);
                        if (_filter.isGreen) resultingSpecification = resultingSpecification.And(isGreen);
                        if (_filter.isColorless) resultingSpecification = resultingSpecification.And(isColorless);
                        if (_filter.isMulticolored) resultingSpecification = resultingSpecification.And(isMulticolored);
                        if (_filter.isArtifact) resultingSpecification = resultingSpecification.And(isArtifact);
                        if (_filter.isCreature) resultingSpecification = resultingSpecification.And(isCreature);
                        break;
                    }
                case FilterMode.OR:
                    {
                        var colorSpecification = new EmptySpecification().And(new EmptySpecification());
                        if (_filter.isWhite) colorSpecification = colorSpecification.Or(isWhite);
                        if (_filter.isBlue) colorSpecification = colorSpecification.Or(isBlue);
                        if (_filter.isBlack) colorSpecification = colorSpecification.Or(isBlack);
                        if (_filter.isRed) colorSpecification = colorSpecification.Or(isRed);
                        if (_filter.isGreen) colorSpecification = colorSpecification.Or(isGreen);
                        if (_filter.isColorless) colorSpecification = colorSpecification.Or(isColorless);
                        if (_filter.isMulticolored) colorSpecification = colorSpecification.Or(isMulticolored);

                        resultingSpecification = resultingSpecification.And(colorSpecification);

                        break;
                    }
                default: break;
            }

            var finalQuery = from card in _cardCollection
                             where resultingSpecification.IsSatisfiedBy(card)
                             select card;

            return finalQuery.ToList();

        }

    }
}
