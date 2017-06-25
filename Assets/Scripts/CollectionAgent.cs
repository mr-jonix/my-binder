using MyBinder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionAgent : MonoBehaviour {

    public static CollectionAgent instance = null;

    private MTGCollection collection = null;

    public MTGCollection Collection
    {
        get
        {
            return collection;
        }

        set
        {
            collection = value;
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

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a CollectionAgent.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization

    public void UpdateQuantities(MTGCard _card, string _multiverseid, CardTreatment _treatment, int _amount)
    {
        if (collection != null)
        {
            collection.UpdateQuantity(_card, _multiverseid, _treatment, _amount);
        }
    }
    
}
