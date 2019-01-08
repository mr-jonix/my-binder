using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangToggleTextUpdater : MonoBehaviour {

    public UnityEngine.UI.Text text;

    public void UpdateText()
    {
        if (text != null)
        {
            switch (ConfigAgent.instance.languageMode)
            {
                case LanguageMode.ENGLISH: text.text = "Eng";
                    break;
                case LanguageMode.RUSSIAN: text.text = "Rus";
                    break;
                default: text.text = "Other";
                    break;
            }
        }
    }
}
