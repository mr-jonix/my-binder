using MyBinder;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

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

    public void UpdateQuantities(MTGCard _card, LanguageMode _language, CardTreatment _treatment, int _amount)
    {
        if (collection != null)
        {
            collection.UpdateQuantity(_card, _language, _treatment, _amount);
        }
    }

    internal MTGQuantities RetrieveQuantities(MTGCard cardLink, LanguageMode languageMode)
    {
        var _result = new MTGQuantities();
        if (collection != null)
        {
            _result = collection.RetrieveQuantities(cardLink, languageMode);
        }

        return _result;
    }

    private void Start()
    {
        Collection = new MTGCollection();
        LoadCollection();
    }

    public void SaveCollection()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(ConfigAgent.instance.DefaultCollection);

        if (Collection != null && ConfigAgent.instance.DefaultCollection != null)
        {
            bf.Serialize(file, Collection);
            file.Close();
        }
    }
    public void SaveCollection(string path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);

        if (Collection != null && ConfigAgent.instance.DefaultCollection != null)
        {
            bf.Serialize(file, Collection);
            file.Close();
        }

        ConfigAgent.instance.DefaultCollection = path;
    }

    public void LoadCollection(string path)
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path,FileMode.Open);
            Collection = (MTGCollection)bf.Deserialize(file);
            file.Close();
            ConfigAgent.instance.DefaultCollection = path;
        }
    }

    public void LoadCollection()
    {
        string path = ConfigAgent.instance.DefaultCollection;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            Collection = (MTGCollection)bf.Deserialize(file);
            file.Close();
            ConfigAgent.instance.DefaultCollection = path;
        }
    }
}
