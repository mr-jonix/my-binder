using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumView : MonoBehaviour
{

    public List<CardView> cardViews;
    public List<MTGCard> cardList;
    public int page = 0;

    private void Start()
    {
        cardList = SearchAgent.instance.currentSearchResults;
    }

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

    public void UpdateCardViews(List<MTGCard> _cardList)
    {
        page = 0;
        cardList = _cardList;
        Debug.Log("new album card list size is " + cardList.Count);
        for (int i = 0; i < cardViews.Count; i++)
        {
            if (page+i < cardList.Count)
            {
                cardViews[i].gameObject.SetActive(true);
                cardViews[i].SetCardLink(cardList[page*18+i]);
            }
            else
            {
                cardViews[i].gameObject.SetActive(false);
            }
        }

    }

    public void UpdateCardViews()
    {
        for (int i = 0; i < cardViews.Count; i++)
        {
            if ((page*18)+i < cardList.Count)
            {
                cardViews[i].gameObject.SetActive(true);
                cardViews[i].SetCardLink(cardList[page*18+i]);
            }
            else
            {
                cardViews[i].gameObject.SetActive(false);
            }
        }

    }

    public void NextPage()
    {
        if (page  < cardList.Count / 18) page++;
        UpdateCardViews();
        SelectionAgent.instance.Deselect();
    }

    public void PrevPage()
    {
        if (page > 0) page--;
        UpdateCardViews();
        SelectionAgent.instance.Deselect();

    }
}
