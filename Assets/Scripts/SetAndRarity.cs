using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAndRarity : MonoBehaviour
{
    public KeyruneMapObject keyruneMap;
    public Text setSymbolText;
    public Outline outline;
    public Color commonColor;
    public Color uncommonColor;
    public Color rareColor;
    public Color mythicColor;
    public Color specialColor;

    public void UpdateRarity(MTGCard _card)
    {
        Color rarityColor = Color.black;
        Color outlineColor = Color.white;
        if (keyruneMap)
        {
            setSymbolText.text = keyruneMap.ConvertSetCode(_card.setCode);
        }
        switch (_card.rarity)
        {
            case "common": break;
            case "uncommon": rarityColor = uncommonColor;
                outlineColor = Color.black;
                break;
            case "rare":
                if (!_card.isTimeshifted)
                {
                    rarityColor = rareColor;
                    outlineColor = Color.black;
                }
                else
                {
                    rarityColor = specialColor;
                    outlineColor = Color.black;
                }
                break;
            case "mythic": rarityColor = mythicColor;
                outlineColor = Color.black;
                break;
            case "special": rarityColor = specialColor;
                outlineColor = Color.black;
                break;

            default: break;
        }

        setSymbolText.color = rarityColor;
        outline.effectColor = outlineColor;
    }
}
