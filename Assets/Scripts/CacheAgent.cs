using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[Serializable]
public class CacheAgent : MonoBehaviour
{

    public static CacheAgent instance = null;
    public Dictionary<string, ScryfallPriceObject> priceCache;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadCaches()
    {
        //load price cache;
        if (File.Exists(Application.persistentDataPath + "//priceCache.cache"))
        {
            var path = Application.persistentDataPath + "//priceCache.cache";
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            priceCache = (Dictionary<string, ScryfallPriceObject>)bf.Deserialize(file);
            file.Close();
        }
        else priceCache = new Dictionary<string, ScryfallPriceObject>();
    }

    public void SaveCaches()
    {
        var path = Application.persistentDataPath + "//priceCache.cache";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);

        if (priceCache!=null)
        {
            bf.Serialize(file, priceCache);
            file.Close();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadCaches();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        SaveCaches();
    }
}
