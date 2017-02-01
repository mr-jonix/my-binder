using UnityEngine;
using System.Collections.Generic;
using System;
namespace MyBinder
{
    [Serializable]
    public class MTGDatabase
    {
        public List<MTGSet> sets;
        DatabaseVersionFormat databaseVersion;
        string lastRevision;

        public MTGDatabase()
        {
            sets = new List<MTGSet>();
            databaseVersion = new DatabaseVersionFormat(0, 0, 0);
            lastRevision = DateTime.Now.ToString();
        }

        public MTGDatabase(string JSONSource)
        {
            sets = JsonUtility.FromJson<List<MTGSet>>(JSONSource);
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

        public List<string> GetListOfSetNames()
        {
            List<string> result = new List<string>();
            foreach (MTGSet set in sets)
            {
                result.Add(set.name);
                Debug.Log(set.name);
            }
            return result;
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
}
