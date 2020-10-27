using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LangerNetwork.Debugging
{
    [Serializable]
    public partial class DebugHelper
    {
        [Tooltip("Toggle debug mode for logging(On = always on, Off = always off, Use Global = use global setting in ProjectConfigTemplate")]
        public DebugMode _debugMode;

        protected List<DebugProfile> debugProfiles = new List<DebugProfile>();

        public bool debugMode
        {
            get
            {
                if (_debugMode == DebugMode.On)
                    return true;
                else if (_debugMode == DebugMode.Off)
                    return false;
                else
                    return ProjectConfigTemplate.singleton.globalDebugMode;
            }
        }

        public void Log(string message, bool trace=true)
        {
            DebugManager.WriteToLog(message, LogType.Log, trace);
        }

        public void LogWarning(string message, bool trace=true)
        {
            DebugManager.WriteToLog(message, LogType.Warning, trace);
        }

        public void LogError(string message, bool trace=true)
        {
            DebugManager.WriteToLog(message, LogType.Error, trace);
        }

        public void LogFormat(params string[] list)
        {
            DebugManager.LogFormat(list);
        }

        public void StartProfile(string name)
        {
            if (!debugMode)
                return;
            if (HasProfile(name))
                RestartProfile(name);
            else
                AddProfile(name);
        }

        public void StopProfile(string name)
        {
            if (!debugMode)
                return;
            int index = GetProfileIndex(name);
            if (index != -1)
                debugProfiles[index].Stop();
        }

        public void PrintProfile(string name)
        {
            if (!debugMode)
                return;
            int index = GetProfileIndex(name);
            if (index != -1)
                Log(debugProfiles[index].Print);
        }

        public void Reset()
        {
            if (!debugMode)
                return;
            foreach (DebugProfile profile in debugProfiles)
                profile.Reset();
        }

        protected bool HasProfile(string _name)
        {
            return debugProfiles.Any(x => x.name == _name);
        }
        
        protected int GetProfileIndex(string _name)
        {
            return debugProfiles.FindIndex(x => x.name == _name);
        }

        protected void AddProfile(string name)
        {
            debugProfiles.Add(new DebugProfile(name));
        }

        protected void RestartProfile(string name)
        {
            int index = GetProfileIndex(name);
            if (index != -1)
                debugProfiles[index].Restart();
        }
    }
}
