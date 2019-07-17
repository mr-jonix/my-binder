using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFilterDropdown : MonoBehaviour
{
    public Dropdown dropdown;

    public void UpdateOptions()
    {
        dropdown.ClearOptions();
        dropdown.options.Add(new Dropdown.OptionData("All"));
        if (dropdown)
        foreach (MTGSet _set in DBAgent.instance.DB.sets)
        {
                dropdown.options.Add(new Dropdown.OptionData("[" + _set.code + "] " + _set.name));
        }

        dropdown.value = 0;
    }

    public void UpdateFilter(int index)
    {
        SearchAgent.instance.filter.setCodes.Clear();
        if (index != 0) { 
        SearchAgent.instance.filter.setCodes.Add(DBAgent.instance.DB.sets[index-1].code);
        }
        SearchAgent.instance.isUpdated = true;
    }

}
