using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumView : MonoBehaviour
{

    public List<CardView> cardViews;
    public List<MTGCard> cardList;
    public int page = 0;
    public Text pageNumberLabel;
    public Button nextPageButton;
    public Button prevPageButton;

    private void Start()
    {
        cardList = SearchAgent.instance.currentSearchResults;
        UpdatePagination();
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
        UpdatePagination();
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

    public void UpdatePagination()
    {
        if (pageNumberLabel != null)
        {
            pageNumberLabel.text = "Page " + (page+1) + " of " + Mathf.CeilToInt(cardList.Count / 18f);
        }
        if (prevPageButton != null)
        {
            if (page == 0)
            {
                prevPageButton.interactable = false;
            }
            else
            {
                prevPageButton.interactable = true;
            }

            if (nextPageButton != null)
            {
                if (page < cardList.Count / 18)
                {
                    nextPageButton.interactable = true;
                }
                else
                {
                    nextPageButton.interactable = false;
                }
            }
        }
    }

    public void NextPage()
    {
        if (page  < cardList.Count / 18) page++;
        UpdateCardViews();
        UpdatePagination();
        SelectionAgent.instance.Deselect();
    }

    public void PrevPage()
    {
        if (page > 0) page--;
        UpdateCardViews();
        UpdatePagination();
        SelectionAgent.instance.Deselect();

    }
}
