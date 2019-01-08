using MyBinder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBAgent : MonoBehaviour {

    public static DBAgent instance = null;
    private MTGDatabase dB;

    public TextAsset[] JSONSource { get; private set; }

    public MTGDatabase DB
    {
        get
        {
            return dB;
        }

        set
        {
            dB = value;
        }
    }

    public void InitDBFromJSON()
    {
        DB = new MTGDatabase();
        JSONSource = Resources.LoadAll<TextAsset>("JSON");
        foreach (TextAsset json in JSONSource)
        {
            DB.AddSet(JsonUtility.FromJson<MTGSet>(json.text));
        }

        UpdateCardsWithSetCode();
    }

    public List<MTGCard> GetCardsFromSets(List<MTGSet> sets)
    {
        var cards = new List<MTGCard>();
        foreach (MTGSet set in sets)
        {
            if (set.cards != null)
            {
                cards.AddRange(set.cards);
            }
        }
        return cards;
    }

    public List<MTGToken> GetTokensFromSets(List<MTGSet> sets)
    {
        var tokens = new List<MTGToken>();
        foreach (MTGSet set in sets)
        {
            if (set.tokens != null)
            {
                tokens.AddRange(set.tokens);
            }
        }
        return tokens;
    }

    public void UpdateCardsWithSetCode()
    {
        foreach (MTGSet set in DB.sets)
        {
            foreach (MTGCard card in set.cards)
            {
                card.setCode = set.code;
            }
        }
    }

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a DBAgent.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        InitDBFromJSON();
        if (DB.sets.Count > 0)
        {
            Debug.Log(DB.sets.Count + " sets loaded");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
