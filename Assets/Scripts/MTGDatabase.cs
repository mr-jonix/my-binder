using UnityEngine;
using System.Collections.Generic;

public struct DatabaseVersionFormat
{
    public int majorVersion;   //Major version should update whenever a standart rotation takes place;
    public int minorVersion;   //Minor version should update whenever a new set is added;
    public int revision;       //Revision should only update if an error has been found and fixed.
}

public class MTGDatabase
{
    List<MTGSet> sets;
    DatabaseVersionFormat databaseVersion;

    public bool UpdateVersion(DatabaseVersionFormat version)
    {
        if ((version.majorVersion > databaseVersion.majorVersion) ||
            (version.minorVersion >= databaseVersion.minorVersion && version.majorVersion==databaseVersion.majorVersion) ||
            (version.minorVersion == databaseVersion.minorVersion && version.majorVersion == databaseVersion.majorVersion &&version.revision > databaseVersion.revision))
        {
            databaseVersion = version;
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
