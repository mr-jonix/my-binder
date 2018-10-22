﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System;

[Serializable]
public class CardViewHeaderColor
{
    [SerializeField]
    public Color headerColor = new Color(0f, 0f, 0f);
    [SerializeField]
    public Color headerTextColor = new Color(1f, 1f, 1f);
}

public class CardView : MonoBehaviour {

    public MTGCard cardLink;
    public Sprite defaultImage;
    public UnityEngine.UI.RawImage cardImageObject;
    public bool wasUpdated = true;
    public GameObject loadingIndicator;
    public int timer = 30;
    public CardViewHeaderColor[] colorPresets = new CardViewHeaderColor[7];
    public TextMeshProUGUI headerText;
    public UnityEngine.UI.Image headerBG;


	// Use this for initialization
	void Start () {
        cardImageObject.texture = new Texture2D(488,680,TextureFormat.ARGB32,false);
        timer = ConfigAgent.instance.ImageUpdateTimer;
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
            SetImageFromCacheOrURL(cardLink.uuid.ToString());
            //cardImageObject.gameObject.SetActive(true); Unoptimal solution

            timer = ConfigAgent.instance.ImageUpdateTimer;
        }
	}

    public IEnumerator SetImageFromURL(string url, string uuid)
    {
        Debug.Log("Start download from " + url);

        // Start a download of the given URL
        WWW www = new WWW(url);

        // Wait for download to complete
        yield return www;
        Debug.Log("download OK");
        
        // assign texture
        cardImageObject.texture = www.texture;
        ImageUpdated();

        File.WriteAllBytes(ConfigAgent.instance.imageSaveDataPath+uuid+".png", ImageConversion.EncodeToPNG(www.texture));
    }

    public void ImageUpdated()
    {
        loadingIndicator.SetActive(false);
    }

    public void SetImageFromCacheOrURL(string uuid)
    {
        string filePath = ConfigAgent.instance.imageSaveDataPath + uuid + ".png";
        bool imageCached = File.Exists(filePath);

        if (!imageCached)
        {
            string URLpath = "https://api.scryfall.com/cards/" + uuid + "?format=image&version=normal";
            StartCoroutine(SetImageFromURL(URLpath, uuid));
            wasUpdated = true;
        }
        else
        {
            ImageConversion.LoadImage((Texture2D)cardImageObject.texture, File.ReadAllBytes(filePath));
            wasUpdated = true;
            ImageUpdated();
        }
    }

    public void SetCardLink(MTGCard card)
    {
        cardLink = card;
        headerText.text = card.name +" "+MTGFormatter.FormatManaCost(card.manaCost);
        headerText.color = GetHeaderTextColor(card);
        headerBG.color = GetHeaderColor(card);
        //cardImageObject.gameObject.SetActive(false); Unoptimal solution
        loadingIndicator.SetActive(true);
        wasUpdated = true;
    }

    private Color GetHeaderTextColor(MTGCard card)
    {
        if (card.colors.Count > 1)
        {
            return colorPresets[5].headerTextColor;
        }
        else
        {
            if (card.colors.Contains("W")) return colorPresets[0].headerTextColor;
            if (card.colors.Contains("U")) return colorPresets[1].headerTextColor;
            if (card.colors.Contains("B")) return colorPresets[2].headerTextColor;
            if (card.colors.Contains("R")) return colorPresets[3].headerTextColor;
            if (card.colors.Contains("G")) return colorPresets[4].headerTextColor;
        }

        return colorPresets[6].headerTextColor;
    }

    private Color GetHeaderColor(MTGCard card)
    {

            if (card.colors.Count > 1)
            {
                return colorPresets[5].headerColor;
            }
            else
            {
                if (card.colors.Contains("W")) return colorPresets[0].headerColor;
            if (card.colors.Contains("U")) return colorPresets[1].headerColor;
            if (card.colors.Contains("B")) return colorPresets[2].headerColor;
            if (card.colors.Contains("R")) return colorPresets[3].headerColor;
            if (card.colors.Contains("G")) return colorPresets[4].headerColor;
                               }

        return colorPresets[6].headerColor;
    }
}
