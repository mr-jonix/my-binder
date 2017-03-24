using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MyBinder;

public class SimpleSearchField : MonoBehaviour
{

    public SearchEngine _searchEngine;
    public InputField _inputField;
    public TextMeshProUGUI _text;
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

    void Start()
    {
        string json = _jsonSource.text;
        _mtgCardSet = JsonUtility.FromJson<MTGSet>(json);
        DoSearchAndUpdate();
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
                name = _inputField.text                
            };
            if (_modeAnd.isOn) myFilter.filterMode = MyBinder.FilterMode.AND;
            if (_modeOr.isOn) myFilter.filterMode = MyBinder.FilterMode.OR;
            _searchEngine.SearchFooAdv(myFilter, _mtgCardSet.cards, _text);
        }
        else
        {
            print("Not everything is assigned, cannot search!!!");
        }
    }

}
