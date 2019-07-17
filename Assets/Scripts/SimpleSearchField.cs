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
            SearchAgent.instance.filter.name = _inputField.text;
            SearchAgent.instance.isUpdated = true;
        }
    }

}
