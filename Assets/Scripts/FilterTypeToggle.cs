using UnityEngine;
using UnityEngine.UI;


public enum MTGType
{
    CREATURE,ARTIFACT,SORCERY,INSTANT,ENCHANTMENT,LAND,PLANESWALKER,TRIBAL
}

public class FilterTypeToggle : MonoBehaviour
{
    public Toggle toggle;
    public MTGType type;
    void Start()
    {
        toggle = gameObject.GetComponent<Toggle>();
    }

    public void UpdateFilter()
    {
        switch (type)
        {
            case MTGType.CREATURE:
                SearchAgent.instance.filter.isCreature = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGType.ARTIFACT:
                SearchAgent.instance.filter.isArtifact = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGType.SORCERY:
                SearchAgent.instance.filter.isSorcery = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGType.INSTANT:
                SearchAgent.instance.filter.isInstant = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGType.ENCHANTMENT:
                SearchAgent.instance.filter.isEnchantment = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGType.LAND:
                SearchAgent.instance.filter.isLand = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGType.PLANESWALKER:
                SearchAgent.instance.filter.isPlaneswalker = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case MTGType.TRIBAL:
                SearchAgent.instance.filter.isTribal = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            default: break;
        }        
    }
}
