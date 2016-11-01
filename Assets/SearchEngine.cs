using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class SearchEngine : MonoBehaviour {

    public void SearchFoo(string nameToFind, List<MTGCard> cardSetToSearch, Text textToUpdate)
    {
        List<MTGCard> FilteredList = CardSearch.SimpleSearch(cardSetToSearch,nameToFind);
        textToUpdate.text = string.Empty;
        foreach (MTGCard card in FilteredList)
        {
            textToUpdate.text += card.name +" "+card.manaCost+ "\n";
        }
    }

    public void SearchFooAdv(CardFilter filter, List<MTGCard> cardSetToSearch, TextMeshProUGUI textToUpdate)
    {
        List<MTGCard> FilteredList = CardSearch.AdvancedSearch(cardSetToSearch, filter, true);
        textToUpdate.text = "total entries: "+FilteredList.Count+"\n";
        foreach (MTGCard card in FilteredList)
        {
            string _manaCost = card.manaCost == null ? string.Empty : card.manaCost;
            textToUpdate.text += card.name + " " + MTGFormatter.FormatManaCost(_manaCost) + "\n";
        }
    }

}
