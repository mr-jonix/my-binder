using UnityEngine;
using System.Collections.Generic;
using System;

public struct DatabaseVersionFormat
{
    public int majorVersion;   //Major version should update whenever a standart rotation takes place;
    public int minorVersion;   //Minor version should update whenever a new set is added;
    public int revision;       //Revision should only update if an error has been found and fixed.
    public string revisionNotes;

    public DatabaseVersionFormat(int major, int minor, int rev)
    {
        majorVersion = major;
        minorVersion = minor;
        revision = rev;
        revisionNotes = string.Empty;
    }

}

[Serializable]
public class MTGDatabase
{
    List<MTGSet> sets;
    DatabaseVersionFormat databaseVersion;
    string lastRevision;

    public MTGDatabase()
    {
        sets = new List<MTGSet>();
        databaseVersion = new DatabaseVersionFormat(0, 0, 0);
        lastRevision = DateTime.Now.ToString();
    }

    public bool UpdateVersion(DatabaseVersionFormat version)
    {
        if ((version.majorVersion > databaseVersion.majorVersion) ||
            (version.minorVersion >= databaseVersion.minorVersion && version.majorVersion == databaseVersion.majorVersion) ||
            (version.minorVersion == databaseVersion.minorVersion && version.majorVersion == databaseVersion.majorVersion && version.revision > databaseVersion.revision))
        {
            databaseVersion = version;
            lastRevision = DateTime.Now.ToString();
            return true;
        }
        else
        {
            Debug.Log("Database version cannot be downgraded");
            return false;
        }
    }

    public void AddSet(MTGSet mtgSet)
    {
        sets.Add(mtgSet);
    }

    public static MTGSet ImportJSON(string mtgSetJSON)
    {
        //TO DO: Add update functionality for updating existing set data
        MTGSet _set = JsonUtility.FromJson<MTGSet>(mtgSetJSON);
        return _set;
    }

}
