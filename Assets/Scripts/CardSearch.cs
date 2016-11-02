using UnityEngine;
using System.Collections.Generic;
using System.Linq;


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


}

public class CardFilter
{
    public string name = string.Empty;
    public bool isWhite = false;
    public bool isBlue = false;
    public bool isBlack = false;
    public bool isRed = false;
    public bool isGreen = false;
    public bool isMulticolored = false;
    public bool isColorless = false;

}
