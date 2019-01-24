using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PriceRetriever : MonoBehaviour
{
    public UnityEngine.UI.Text regPriceLabel;
    public UnityEngine.UI.Text foilPriceLabel;
    public CardView cardView;
    public Dictionary<string,ScryfallPriceObject> priceCache = new Dictionary<string, ScryfallPriceObject>();
    // Start is called before the first frame update

    public IEnumerator RetrievePrice(MTGCard card)
    {
        //DownloadHandler dHandler;
        //UploadHandler uploadHandler;
        var url = "https://api.scryfall.com/cards/" + card.scryfallId;
        var www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            ScryfallPriceObject scryfallPriceObject = JsonUtility.FromJson<ScryfallPriceObject>(www.downloadHandler.text);
            scryfallPriceObject.date = DateTime.Now;
            priceCache.Add(card.scryfallId, scryfallPriceObject);
            regPriceLabel.text = scryfallPriceObject.usd;
        }
    }

    public void RetrievePriceFromURLOrCache()
    {
        if (cardView != null && cardView.cardLink != null)
            
        {
            MTGCard card = cardView.cardLink;
            ScryfallPriceObject priceRecord;
            if (priceCache.ContainsKey(card.scryfallId))
            {
                priceCache.TryGetValue(card.scryfallId, out priceRecord);
                if (priceRecord.date.Date == System.DateTime.Now.Date)
                {
                    regPriceLabel.text = priceRecord.usd;
                }
                else
                {
                    priceCache.Remove(card.scryfallId);
                    StartCoroutine(RetrievePrice(card));
                }
            }
            else
            {
                StartCoroutine(RetrievePrice(card));
            }
        }
    }
}
