using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SimpleSearchField : MonoBehaviour
{

    public SearchEngine _searchEngine;
    public InputField _inputField;
    public TextMeshProUGUI _text;
    public MTGSet _mtgCardSet;
    public TextAsset jsonSource;
    public Toggle _isWhite;
    public Toggle _isBlue;
    public Toggle _isBlack;
    public Toggle _isRed;
    public Toggle _isGreen;
    public Toggle _isColorless;
    public Toggle _isMulticolored;

    void Start()
    {
        string json = jsonSource.text;
        _mtgCardSet = JsonUtility.FromJson<MTGSet>(json);
        DoSearchAndUpdate();
    }

    public void DoSearchAndUpdate()
    {
        if (_searchEngine != null && _inputField != null && _text != null && _mtgCardSet != null)
        {
            CardFilter myFilter = new CardFilter();
            myFilter.isWhite = _isWhite.isOn;
            myFilter.isBlue = _isBlue.isOn;
            myFilter.isBlack = _isBlack.isOn;
            myFilter.isRed = _isRed.isOn;
            myFilter.isGreen = _isGreen.isOn;
            myFilter.isColorless = _isColorless.isOn;
            myFilter.isMulticolored = _isMulticolored.isOn;
            myFilter.name = _inputField.text;
            _searchEngine.SearchFooAdv(myFilter, _mtgCardSet.cards, _text);
        }
        else
        {
            print("Not everything is assigned, cannot search!!!");
        }
    }

}
