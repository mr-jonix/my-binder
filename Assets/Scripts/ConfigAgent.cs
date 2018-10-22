using MyBinder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class ConfigAgent : MonoBehaviour {

    public static ConfigAgent instance = null;

    [SerializeField]
    private string defaultCollection;

    public string DefaultCollection
    {
        get
        {
            return defaultCollection;
        }

        set
        {
            defaultCollection = value;
        }
    }

    public int AutoSaveInterval = 1; // in minutes
    public int AutoSaveTimer = 3000;
    public int SearchResultsLimit = 100;
    public string imageSaveDataPath = "D:/temp/images//";
    public int ImageUpdateTimer = 10;
    public LanguageMode languageMode = LanguageMode.ENGLISH;

    void FixedUpdate()
    {
        //Autosave routine
        if (AutoSaveTimer-- == 0)
        {
            //Save function here
            Debug.Log("Save performed at " + Time.time);

            //Reset timer
            AutoSaveTimer = AutoSaveInterval * 3000;
        }

    }

    public void ToggleLanguageMode()
    {
        languageMode = (languageMode == LanguageMode.ENGLISH) ? LanguageMode.RUSSIAN : LanguageMode.ENGLISH;
    }

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a ConfigAgent.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        AutoSaveTimer = AutoSaveInterval * 3600;

        if (!File.Exists(imageSaveDataPath)){
            Directory.CreateDirectory(imageSaveDataPath);
        }
    }

}
