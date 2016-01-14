using System;
using System.Collections;

namespace ManagementStore_DomainLogic.Utils
{
    public class FastCache
    {
        private Hashtable _mCache;
        private readonly int _mMaxInHash;

        private Hashtable GetHashTable()
        {
            return _mCache ?? (_mCache = new Hashtable());
        }

        public object GetValue(string section, string key)
        {
            //This object may exist in shared memory.. if too much is cached.. clear cache and start again..
            if (GetHashTable().Count > 1000)
            {
                _mCache = null;
            }
            if (GetHashTable().ContainsKey(section + "/" + key))
            {
                var sValue = GetHashTable()[section + "/" + key];
                return sValue;
            }

            return null;
        }

        public void SetValue(string section, string key, object value)
        {
            //This object may exist in shared memory.. if too much is cached.. clear cache and start again..
            if (GetHashTable().Count > _mMaxInHash)
            {
                _mCache = null;
            }
            if (GetHashTable().ContainsKey(section + "/" + key) == false)
            {
                GetHashTable().Add(section + "/" + key, value);
            }
            else
            {
                GetHashTable().Remove(section + "/" + key);
                GetHashTable().Add(section + "/" + key, value);
            }
        }

        public FastCache(int maxInHash)
        {
            _mMaxInHash = maxInHash;
            GetHashTable();
        }
    }
}