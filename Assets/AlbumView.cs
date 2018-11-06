using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumView : MonoBehaviour
{

    public List<CardView> cardViews;

    public void UpdateQuantities()
    {
        foreach (CardView cardView in cardViews)
        {
            cardView.quantitiesUpdated = true;
        }
    }

    public void UpdateHeaders()
    {
        foreach (CardView cardView in cardViews)
        {
            cardView.UpdateHeader();
        }
    }

    public void UpdateCardViews(List<MTGCard> cardList)
    {

        for (int i = 0; i < cardViews.Count; i++)
        {
            if (i < cardList.Count)
            {
                cardViews[i].gameObject.SetActive(true);
                cardViews[i].SetCardLink(cardList[i]);
            }
            else
            {
                cardViews[i].gameObject.SetActive(false);
            }
        }

    }
}
