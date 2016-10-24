using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class JSONTest : MonoBehaviour {

    public TextAsset jsonSource;

	// Use this for initialization
	void Start () {
        string json = jsonSource.text;
        MTGSet TestSet = JsonUtility.FromJson<MTGSet>(json);
        print(TestSet.name);
        print(TestSet.translations.ru);
        List<MTGCard> FilteredList = TestSet.cards.Where(x => x.types.Contains("Planeswalker")).ToList();
        foreach(MTGCard card in FilteredList)
        {
            print(card.foreignNames[card.foreignNames.FindIndex(x => x.language =="Russian")].name + " at #"+card.number);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
