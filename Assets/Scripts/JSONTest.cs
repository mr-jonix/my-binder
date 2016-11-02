using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class JSONTest : MonoBehaviour
{

    public TextAsset jsonSource;

    // Use this for initialization
    void Start()
    {
        string json = jsonSource.text;
        MTGSet TestSet = JsonUtility.FromJson<MTGSet>(json);
        print(TestSet.name);
        print(TestSet.translations.tw);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
