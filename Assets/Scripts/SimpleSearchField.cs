using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using MyBinder;
using System.Collections;

public class SimpleSearchField : MonoBehaviour
{
    public bool _allSets = false;
    public InputField _inputField;
    public InputField _cmcInputField;
    //public MTGDatabase _DB;
    //public MTGSet _mtgCardSet;
    //public TextAsset _jsonSource;
    //public Toggle _isWhite;
    //public Toggle _isBlue;
    //public Toggle _isBlack;
    //public Toggle _isRed;
    //public Toggle _isGreen;
    //public Toggle _isColorless;
    //public Toggle _isMulticolored;
    //public Toggle _modeAnd;
    //public Toggle _modeOr;
    //public Toggle _isCreature;
    //public Toggle _isArtifact;
    //public Toggle _isLand;
    //public Toggle _isInstant;
    //public Toggle _isSorcery;
    //public Toggle _isEnchantment;
    //public Toggle _isPlaneswalker;
    //public Toggle _isTribal;

    void Start()
    {
        DoSearchAndUpdate();
    }

    IEnumerator SearchWithDelay()
    {
        yield return new WaitForSeconds(ConfigAgent.instance.SearchInputDelay);
        DoSearchAndUpdate();
    }

    public void UpdateSearchWithDelay()
    {
        this.StopAllCoroutines();
        StartCoroutine(SearchWithDelay());
    }

    public void DoSearchAndUpdate()
    {
        if (SearchAgent.instance != null && _inputField != null)
        {
            //CardFilter myFilter = new CardFilter()
            //{
            //    isWhite = _isWhite.isOn,
            //    isBlue = _isBlue.isOn,
            //    isBlack = _isBlack.isOn,
            //    isRed = _isRed.isOn,
            //    isGreen = _isGreen.isOn,
            //    isColorless = _isColorless.isOn,
            //    isMulticolored = _isMulticolored.isOn,
            //    isArtifact = _isArtifact.isOn,
            //    isCreature = _isCreature.isOn,
            //    isEnchantment = _isEnchantment.isOn,
            //    isInstant = _isInstant.isOn,
            //    isSorcery = _isSorcery.isOn,
            //    isLand = _isLand.isOn,
            //    isPlaneswalker = _isPlaneswalker.isOn,
            //    isTribal = _isTribal.isOn,
            //    name = _inputField.text,
            //    convertedManaCost = (_cmcInputField.text == string.Empty) ? -17f : float.Parse(_cmcInputField.text)
            //};
            //if (_modeAnd.isOn) myFilter.filterMode = MyBinder.FilterMode.AND;
            //if (_modeOr.isOn) myFilter.filterMode = MyBinder.FilterMode.OR;

            SearchAgent.instance.filter.name = _inputField.text;
            SearchAgent.instance.isUpdated = true;
        }
    }

}
