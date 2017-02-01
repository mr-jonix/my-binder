using System;

namespace MyBinder
{
    [Serializable]
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
}
