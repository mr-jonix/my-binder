using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using MyBinder;

public class SimpleSearchField : MonoBehaviour
{
    public bool _allSets = true;
    public SearchEngine _searchEngine;
    public InputField _inputField;
    public InputField _cmcInputField;
    public TextMeshProUGUI _text;
    public MTGDatabase _DB;
    public MTGSet _mtgCardSet;
    public TextAsset _jsonSource;
    public Toggle _isWhite;
    public Toggle _isBlue;
    public Toggle _isBlack;
    public Toggle _isRed;
    public Toggle _isGreen;
    public Toggle _isColorless;
    public Toggle _isMulticolored;
    public Toggle _modeAnd;
    public Toggle _modeOr;
    public Toggle _isCreature;
    public Toggle _isArtifact;
    public Toggle _isLand;
    public Toggle _isInstant;
    public Toggle _isSorcery;
    public Toggle _isEnchantment;
    public Toggle _isPlaneswalker;
    public Toggle _isTribal;

    void Start()
    {
        //string json = _jsonSource.text;
        //_mtgCardSet = JsonUtility.FromJson<MTGSet>(json);
        //DoSearchAndUpdate();
        if (_allSets)
        {
            var JSONSource = Resources.LoadAll<TextAsset>("JSON");
            foreach (TextAsset json in JSONSource)
            {
                _DB.AddSet(JsonUtility.FromJson<MTGSet>(json.text));
            }
        }
    }

    public void DoSearchAndUpdate()
    {
        if (_searchEngine != null && _inputField != null && _text != null && _mtgCardSet != null)
        {
            CardFilter myFilter = new CardFilter()
            {
                isWhite = _isWhite.isOn,
                isBlue = _isBlue.isOn,
                isBlack = _isBlack.isOn,
                isRed = _isRed.isOn,
                isGreen = _isGreen.isOn,
                isColorless = _isColorless.isOn,
                isMulticolored = _isMulticolored.isOn,
                isArtifact = _isArtifact.isOn,
                isCreature = _isCreature.isOn,
                isEnchantment = _isEnchantment.isOn,
                isInstant = _isInstant.isOn,
                isSorcery = _isSorcery.isOn,
                isLand = _isLand.isOn,
                isPlaneswalker = _isPlaneswalker.isOn,
                isTribal = _isTribal.isOn,
                name = _inputField.text,
                convertedManaCost = (_cmcInputField.text == string.Empty) ? -17f : float.Parse(_cmcInputField.text)
            };
            if (_modeAnd.isOn) myFilter.filterMode = MyBinder.FilterMode.AND;
            if (_modeOr.isOn) myFilter.filterMode = MyBinder.FilterMode.OR;

            _searchEngine.SearchFooAdv(myFilter, DBAgent.instance.GetCardsFromSets(DBAgent.instance.DB.sets), _text);
        }
        else
        {
            print("Not everything is assigned, cannot search!!!");
        }
    }

}
