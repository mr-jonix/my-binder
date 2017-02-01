using MyBinder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateWithSets : MonoBehaviour {

    public TextAsset[] JSONSource;
    public MTGDatabase DB;

	// Use this for initialization
	void Start () {

        DB = new MTGDatabase();
        foreach (TextAsset json in JSONSource)
        {
            DB.AddSet(JsonUtility.FromJson<MTGSet>(json.text));
        }
        gameObject.GetComponent<Dropdown>().AddOptions(DB.GetListOfSetNames());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
