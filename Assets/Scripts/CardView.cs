﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;
using System;
using MyBinder;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public bool isSideView = false;
    public AlbumView albumView;
    public int albumIndex;
    public Animator QuantityAnimator;
    public MTGCard cardLink;
    public Sprite defaultImage;
    public RawImage cardImageObject;
    public bool wasUpdated = true;
    public GameObject loadingIndicator;
    public GameObject selectionUI;
    //public int timer = 30;
    public CardViewHeaderColor[] colorPresets = new CardViewHeaderColor[7];
    public TextMeshProUGUI manaCostText;
    public Text headerText;
    public Image headerBG;
    public bool isSelectable = true;

    public bool quantitiesUpdated = true;
    public Image quantityBaseImage;
    public TextMeshProUGUI totalQuantityTextObject;
    public TextMeshProUGUI regularQuantityTextObject;
    public TextMeshProUGUI foilQuantityTextObject;
    private bool isSelected = false;


    // Use this for initialization
    void Start () {
        cardImageObject.texture = new Texture2D(488,680,TextureFormat.ARGB32,false);
        //timer = ConfigAgent.instance.ImageUpdateTimer;
    }

    private void Update()
    {
        if (wasUpdated)
        {
            UpdateCardView();
        }
        if (quantitiesUpdated)
        {
            UpdateQuantitiesDisplay();
        }
    }

    private void UpdateQuantitiesDisplay()
    {
        if (cardLink != null)
        {
            MTGQuantities _record = CollectionAgent.instance.RetrieveQuantities(cardLink, ConfigAgent.instance.languageMode);
            totalQuantityTextObject.text = _record.total.ToString();
            regularQuantityTextObject.text = _record.regularCurrentLanguage.ToString() + "/" + _record.regularTotal.ToString();
            foilQuantityTextObject.text = _record.foilCurrentLanguage.ToString() + "/" + _record.foilTotal.ToString();

            if (_record.total == 0)
            {
                quantityBaseImage.color = colorPresets[3].headerColor;
            }
            else
            {
                if (_record.regularCurrentLanguage > 0)
                {
                    quantityBaseImage.color = colorPresets[4].headerColor;
                }
                else
                {
                    if (_record.foilCurrentLanguage > 0)
                    {
                        quantityBaseImage.color = colorPresets[5].headerColor;
                    }
                    else
                    {
                        quantityBaseImage.color = colorPresets[6].headerColor;
                    }
                }
            }

            //Debug.Log("Quantities Updated!");
        }
        quantitiesUpdated = false;
    }

    // Update is called once per frame
    void UpdateCardView() {

        //if (timer>=1&&wasUpdated) timer--;

        if (cardLink == null&&wasUpdated)
        {
            cardImageObject.texture = defaultImage.texture;
            totalQuantityTextObject.text = string.Empty;
            regularQuantityTextObject.text = string.Empty;
            foilQuantityTextObject.text = string.Empty;
            wasUpdated = false;
        }
		else 
        if (wasUpdated)
        {
            StopAllCoroutines();
            SetImageFromCacheOrURL(cardLink);
            wasUpdated = false;

            //cardImageObject.gameObject.SetActive(true); Unoptimal solution

            //timer = ConfigAgent.instance.ImageUpdateTimer;
        }
	}

    public IEnumerator SetImageFromURL(string url, string uuid)
    {
        ////Debug.Log("Start download from " + url);

        //// Start a download of the given URL
        //WWW www = new WWW(url);

        //// Wait for download to complete
        //yield return www;
        //Debug.Log("download OK");
        Texture2D texture;

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                texture = DownloadHandlerTexture.GetContent(uwr);
                cardImageObject.texture = texture;
                ImageUpdated();

                File.WriteAllBytes(ConfigAgent.instance.imageSaveDataPath + uuid + ".png", ImageConversion.EncodeToPNG(texture));
            }
        }

        // assign texture

    }

    public void ImageUpdated()
    {
        loadingIndicator.SetActive(false);
    }

    public void SetImageFromCacheOrURL(MTGCard _card)
    {
        string filePath = ConfigAgent.instance.imageSaveDataPath + _card.uuid + ".png";
        bool imageCached = File.Exists(filePath);

        if (!imageCached)
        {
            string DownloadLocation = (_card.layout == "transform" || _card.layout == "flip" || _card.layout == "split" || _card.layout == "meld") ? "multiverse/" + _card.multiverseId : _card.scryfallId;
            string URLpath = "https://api.scryfall.com/cards/" + DownloadLocation + "?format=image&version=normal";
            StartCoroutine(SetImageFromURL(URLpath, _card.uuid));
            wasUpdated = true;
        }
        else
        {
            ImageConversion.LoadImage((Texture2D)cardImageObject.texture, File.ReadAllBytes(filePath));
            wasUpdated = true;
            ImageUpdated();
        }
    }

    public void UpdateHeader()
    {
        string headerName = string.Empty;
        if (cardLink.foreignData.Count > 0)
        {
            switch (ConfigAgent.instance.languageMode)
            {
                case LanguageMode.ENGLISH:
                    headerName = cardLink.name;
                    break;
                case LanguageMode.CHINESE_SIMPLIFIED:
                    headerName = (ConfigAgent.instance.languageMode == LanguageMode.ENGLISH) ? cardLink.name : cardLink.foreignData.Find(_card => _card.language.Contains("Chinese Simplified")).name;
                    break;
                case LanguageMode.CHINESE_TRADITIONAL:
                    headerName = (ConfigAgent.instance.languageMode == LanguageMode.ENGLISH) ? cardLink.name : cardLink.foreignData.Find(_card => _card.language.Contains("Chinese Traditional")).name;
                    break;
                case LanguageMode.FRENCH:
                    headerName = (ConfigAgent.instance.languageMode == LanguageMode.ENGLISH) ? cardLink.name : cardLink.foreignData.Find(_card => _card.language.Contains("French")).name;
                    break;
                case LanguageMode.GERMAN:
                    headerName = (ConfigAgent.instance.languageMode == LanguageMode.ENGLISH) ? cardLink.name : cardLink.foreignData.Find(_card => _card.language.Contains("German")).name;
                    break;
                case LanguageMode.ITALIAN:
                    headerName = (ConfigAgent.instance.languageMode == LanguageMode.ENGLISH) ? cardLink.name : cardLink.foreignData.Find(_card => _card.language.Contains("Italian")).name;
                    break;
                case LanguageMode.SPANISH:
                    headerName = (ConfigAgent.instance.languageMode == LanguageMode.ENGLISH) ? cardLink.name : cardLink.foreignData.Find(_card => _card.language.Contains("Spanish")).name;
                    break;
                case LanguageMode.PORTUGESE:
                    headerName = (ConfigAgent.instance.languageMode == LanguageMode.ENGLISH) ? cardLink.name : cardLink.foreignData.Find(_card => _card.language.Contains("Portugese")).name;
                    break;
                case LanguageMode.JAPANESE:
                    headerName = (ConfigAgent.instance.languageMode == LanguageMode.ENGLISH) ? cardLink.name : cardLink.foreignData.Find(_card => _card.language.Contains("Japanese")).name;
                    break;
                case LanguageMode.KOREAN:
                    headerName = (ConfigAgent.instance.languageMode == LanguageMode.ENGLISH) ? cardLink.name : cardLink.foreignData.Find(_card => _card.language.Contains("Korean")).name;
                    break;
                case LanguageMode.RUSSIAN:
                    headerName = (ConfigAgent.instance.languageMode == LanguageMode.ENGLISH) ? cardLink.name : cardLink.foreignData.Find(_card => _card.language.Contains("Russian")).name;
                    break;

                default:
                    headerName = cardLink.name;
                    break;

            }
        }
        else
        {
            headerName = cardLink.name;
        }
        headerText.text = headerName;
        headerText.color = GetHeaderTextColor(cardLink);
        manaCostText.text = MTGFormatter.FormatManaCost(cardLink.manaCost);
        manaCostText.color = GetHeaderTextColor(cardLink);
        headerBG.color = GetHeaderColor(cardLink);
    }

    public void SetCardLink(MTGCard card)
    {
        cardLink = card;
        UpdateHeader();
        loadingIndicator.SetActive(true);
        wasUpdated = true;
        quantitiesUpdated = true;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSideView)
        {
            QuantityAnimator.SetBool("isSelected", true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected&&!isSideView)
        {
            QuantityAnimator.SetBool("isSelected", false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isSelectable) SelectionAgent.instance.Select(this);
    }

    public void UpdateQuantities(CardTreatment treatment, int amount)
    {
        CollectionAgent.instance.UpdateQuantities(cardLink, ConfigAgent.instance.languageMode, treatment, amount);
        if (albumView != null)
        {
            albumView.UpdateQuantities();
        }
        //quantitiesUpdated = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void Select()
    {
        isSelected = true;
        UpdateSelection();
        QuantityAnimator.SetBool("isSelected", true);
    }

    public void Deselect()
    {
        isSelected = false;
        UpdateSelection();
        QuantityAnimator.SetBool("isSelected", false);
    }

    private void UpdateSelection()
    {
        if (isSelected)
        {
            selectionUI.SetActive(true);
        }
        else selectionUI.SetActive(false);
    }
}
