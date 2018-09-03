using MyBinder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateWithSets : MonoBehaviour {

    public TextAsset[] JSONSource;
    public MTGDatabase DB;
    public SimpleSearchField SearchField;
    public CardView cardViewObject;

	// Use this for initialization
	void Start () {

        DB = new MTGDatabase();
        JSONSource = Resources.LoadAll<TextAsset>("JSON");
        foreach (TextAsset json in JSONSource)
        {
            DB.AddSet(JsonUtility.FromJson<MTGSet>(json.text));
        }
        gameObject.GetComponent<Dropdown>().AddOptions(DB.GetListOfSetNames());
        SendSetChange(0);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SendSetChange(int setIndex)
    {
        if (SearchField != null)
        {
            SearchField._mtgCardSet = DB.sets[setIndex];
            cardViewObject.cardLink = DB.sets[setIndex].cards[0];
            StartCoroutine(cardViewObject.SetImageFromURL("https://img.scryfall.com/cards/normal/en/" + DB.sets[setIndex].code.ToLower()+"/"+ cardViewObject.cardLink.number + ".jpg"));
            SearchField.DoSearchAndUpdate();
        }
    }
}
