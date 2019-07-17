using UnityEngine;
using UnityEngine.UI;

public enum MTGColor
{
    WHITE,BLUE,BLACK,RED,GREEN,COLORLESS,GOLDEN
}

public class FilterColorToggle : MonoBehaviour
{
    public Toggle toggle;
    public MTGColor color;

    private void Start()
    {
        toggle = gameObject.GetComponent<Toggle>();
    }

    public void UpdateFilterColor()
    {
        switch (color)
        {
            case MTGColor.WHITE: SearchAgent.instance.filter.isWhite = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGColor.BLUE: SearchAgent.instance.filter.isBlue = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGColor.BLACK:
                SearchAgent.instance.filter.isBlack = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGColor.RED:
                SearchAgent.instance.filter.isRed = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGColor.GREEN:
                SearchAgent.instance.filter.isGreen = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGColor.COLORLESS:
                SearchAgent.instance.filter.isColorless = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGColor.GOLDEN:
                SearchAgent.instance.filter.isMulticolored = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            default:
                break;
        }
    }

    public void UpdateFilterColorMode()
    {
        SearchAgent.instance.filter.filterMode = toggle.isOn ? MyBinder.FilterMode.AND : MyBinder.FilterMode.OR;
        SearchAgent.instance.isUpdated = true;
    }
}
