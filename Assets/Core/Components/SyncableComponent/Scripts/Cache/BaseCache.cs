using System;

namespace LangerNetwork
{
    public abstract partial class BaseCache
    {
        protected double cacheUpdateInterval = 1f;
        protected double _timerCache = 0;

        public BaseCache(double _cacheUpdateInterval)
        {
            cacheUpdateInterval = _cacheUpdateInterval;
        }
    }
}