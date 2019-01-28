using System;
using System.IO;
using UnityEngine;
using SimpleFileBrowser;

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
    public int AutoSaveTimer = 3600;
    public int SearchResultsLimit = 100;
    public float SearchInputDelay = 0.2f;
    public string imageSaveDataPath = "D:/temp/images//";
    public int ImageUpdateTimer = 10;
    public LanguageMode languageMode = LanguageMode.ENGLISH;

    void FixedUpdate()
    {
        //Autosave routine
        if (AutoSaveTimer-- == 0)
        {
            //Save function here
            CollectionAgent.instance.SaveCollection();
            Debug.Log("Save performed at " + Time.time);

            //Reset timer
            AutoSaveTimer = AutoSaveInterval * 3600;
        }

    }

    public void ToggleLanguageMode()
    {
        languageMode = (languageMode == LanguageMode.ENGLISH) ? LanguageMode.RUSSIAN : LanguageMode.ENGLISH;
    }

    public void ChangeLanguageMode (int mode)
    {
        languageMode = (LanguageMode)mode;
        SearchAgent.instance.isUpdated = true;
    }

    private void SetImageSavePath()
    {
        FileBrowser.ShowLoadDialog((imageSaveDataPath) => { Debug.Log("Selected: " + imageSaveDataPath); },
                                       () => { Debug.Log("Canceled"); },
                                       true, null, "Select Folder", "Select");
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

        LoadConfig();

        if (imageSaveDataPath == "")
        {
            SetImageSavePath();
        }


        if (!File.Exists(imageSaveDataPath)){
            Directory.CreateDirectory(imageSaveDataPath);
        }

        SaveConfig();
    }

    private void OnApplicationQuit()
    {
        SaveConfig();
    }

    public void SaveConfig()
    {
        File.WriteAllText(Application.persistentDataPath+"/my-binder.cfg", JsonUtility.ToJson(this));
    }

    public void LoadConfig()
    {
        if (File.Exists(Application.persistentDataPath + "/my-binder.cfg"))
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(Application.persistentDataPath + "/my-binder.cfg"), this);
        }
    }
}
