using System;
using System.Collections.Generic;

namespace LangerNetwork
{
    public partial class DataCache : BaseCache
    {
        protected Dictionary<int, DataCacheEntry> cacheEntries = new Dictionary<int, DataCacheEntry>();

        public DataCache(double _cacheUpdateInterval) : base(_cacheUpdateInterval)
        {

        }
    }
}
