using UnityEngine;
using UnityEngine.UI;

public class FilterLegalityToggle : MonoBehaviour
{
    public Toggle toggle;
    public LegalityType legalityType;

    public void UpdateFilter()
    {
        switch (legalityType)
        {
            case LegalityType.STANDARD:
                SearchAgent.instance.filter.isStandardLegal = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case LegalityType.MODERN:
                SearchAgent.instance.filter.isModernLegal = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case LegalityType.LEGACY:
                SearchAgent.instance.filter.isLegacyLegal = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            case LegalityType.VINTAGE:
                SearchAgent.instance.filter.isVintageLegal = toggle.isOn;
                SearchAgent.instance.isUpdated = true;
                break;
            default: break;
        }
    }
}
