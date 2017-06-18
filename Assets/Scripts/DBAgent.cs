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
        DB = new MTGDatabase();
        JSONSource = Resources.LoadAll<TextAsset>("JSON");
        foreach (TextAsset json in JSONSource)
        {
            DB.AddSet(JsonUtility.FromJson<MTGSet>(json.text));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
