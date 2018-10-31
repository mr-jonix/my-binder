using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumView : MonoBehaviour {

    public List<CardView> cardViews;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cardViews.Count > 0)
        {

        }
	}

    public void UpdateCardViews(List<MTGCard> cardList)
    {

            for (int i = 0; i<cardViews.Count; i++)
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

public enum LanguageMode
{
    ENGLISH,
    RUSSIAN,
    JAPANESE,
    KOREAN,
    ITALIAN,
    FRENCH,
    GERMAN,
    PORTUGESE,
    CHINESE_SIMPLIFIED,
    CHINESE_TRADITIONAL,
    SPANISH
}