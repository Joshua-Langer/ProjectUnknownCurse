using System;
using UnityEngine;

namespace LangerNetwork
{
    public abstract partial class BaseCacheEntry
    {
        public double timer;
        protected double interval;

        public bool CheckUpdateInterval(double _interval)
        {
            if (interval == 0)
                interval = _interval;
            return Time.time > timer;
        }

        public void RefreshUpdateInterval()
        {
            timer = Time.time + interval;
        }
    }
}

