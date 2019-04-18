using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class KeyruneMapObject : ScriptableObject
{
    public List<KeyruneObject> setCodeMap;

    public string ConvertSetCode(string input)
    {
        if (setCodeMap.Exists(x => x.setCode == input))
            return setCodeMap.Find(x => x.setCode == input).keyruneChar;
        else return setCodeMap.Find(x => x.setCode == "").keyruneChar;
    }
}

[Serializable]
public class KeyruneObject
{
    public string setCode;
    public string keyruneChar;


}