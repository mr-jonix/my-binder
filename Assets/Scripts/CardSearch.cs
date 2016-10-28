using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public static class CardSearch {
    static IEnumerable<T> CreateEmptyEnumerable<T>(IEnumerable<T> templateQuery)
    {
        return Enumerable.Empty<T>();
    }

    public static List<MTGCard> SimpleSearch(List<MTGCard> _cardCollection, string _cardName)
    {
        return _cardCollection.Where(x => x.name.ToLower().Contains(_cardName.ToLower())).ToList();
    }

    public static List<MTGCard> AdvancedSearch(List<MTGCard> _cardCollection, CardFilter _filter)
    {

        //var queryName = from card in _cardCollection
        //                where card.name.ToLower().Contains(_filter.name.ToLower())
        //                select card;
        //var queryIsWhite = from card in _cardCollection
        //                   where card.colors.Contains("white")
        //                   select card;
        //var queryIsBlue = from card in _cardCollection
        //                  where card.colors.Contains("blue")
        //                  select card;
        //var queryIsBlack = from card in _cardCollection
        //                   where card.colors.Contains("black")
        //                   select card;
        //var queryIsRed = from card in _cardCollection
        //                   where card.colors.Contains("red")
        //                   select card;
        //var queryIsGreen = from card in _cardCollection
        //                   where card.colors.Contains("green")
        //                   select card;
        //var queryIsColorless = from card in _cardCollection
        //                       where card.colors.Count == 0
        //                       select card;
        //var queryIsMulticolored = from card in _cardCollection
        //                          where card.colors.Count > 1
        //                          select card;

        //var finalQuery = CreateEmptyEnumerable(queryName);

        ////Main construction of the query below

        //if (_filter.name != string.Empty) 
        var finalQuery = from card in _cardCollection
                         where card.name.ToLower().Contains(_filter.name.ToLower()) || card.ContainsForeign(_filter.name.ToLower()) 
                         select card;
        if (_filter.isWhite) finalQuery = finalQuery.Where(x => x.colors.Contains("White"));
        if (_filter.isBlue) finalQuery = finalQuery.Where(x => x.colors.Contains("Blue"));
        if (_filter.isBlack) finalQuery = finalQuery.Where(x => x.colors.Contains("Black"));
        if (_filter.isRed) finalQuery = finalQuery.Where(x => x.colors.Contains("Red"));
        if (_filter.isGreen) finalQuery = finalQuery.Where(x => x.colors.Contains("Green"));
        if (_filter.isColorless) finalQuery = finalQuery.Where(x => x.colors.Count==0);
        if (_filter.isMulticolored) finalQuery = finalQuery.Where(x => x.colors.Count>1);

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
