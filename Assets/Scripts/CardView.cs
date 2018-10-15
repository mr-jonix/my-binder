using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CardView : MonoBehaviour {

    public MTGCard cardLink;
    public Sprite defaultImage;
    public UnityEngine.UI.RawImage cardImageObject;
    public bool wasUpdated = true;
    public int timer = 60;


	// Use this for initialization
	void Start () {
        cardImageObject.texture = defaultImage.texture;
    }
	
	// Update is called once per frame
	void Update () {

        if (timer>=1&&wasUpdated) timer--;

        if (cardLink == null&&wasUpdated)
        {
            cardImageObject.texture = defaultImage.texture;
            wasUpdated = false;
        }
		else 
        if (wasUpdated&&timer<1)
        {
            SetImageFromCacheOrURL(cardLink.multiverseId.ToString());
            timer = 60;
        }
	}

    public IEnumerator SetImageFromURL(string url, string multiverseId)
    {
        Debug.Log("Start download from " + url);

        // Start a download of the given URL
        WWW www = new WWW(url);

        // Wait for download to complete
        yield return www;
        Debug.Log("download OK");
        
        // assign texture
        cardImageObject.texture = www.texture;

        File.WriteAllBytes(ConfigAgent.instance.imageSaveDataPath+multiverseId+".png", ImageConversion.EncodeToPNG(www.texture));
    }

    public void SetImageFromCacheOrURL(string multiverseId)
    {
        string filePath = ConfigAgent.instance.imageSaveDataPath + multiverseId + ".png";
        bool imageCached = File.Exists(filePath);

        if (!imageCached)
        {
            string URLpath = "https://api.scryfall.com/cards/multiverse/" + multiverseId + "?format=image&version=normal";
            StartCoroutine(SetImageFromURL(URLpath, multiverseId));
            wasUpdated = true;
        }
        else
        {
            ImageConversion.LoadImage((Texture2D)cardImageObject.texture, File.ReadAllBytes(filePath));
            wasUpdated = true;
        }
    }

    public void SetCardLink(MTGCard card)
    {
        cardLink = card;
        wasUpdated = true;
    }
}
