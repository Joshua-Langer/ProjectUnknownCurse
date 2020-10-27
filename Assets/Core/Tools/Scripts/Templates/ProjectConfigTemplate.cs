using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using LangerNetwork.Debugging;
using LangerNetwork.Network;

namespace LangerNetwork
{
    [CreateAssetMenu(fileName = "New Project Configuration", menuName = "Net Game - Configuration/New Project Configuration", order = 999)]
    public partial class ProjectConfigTemplate : ScriptableObject
    {
        [Header("Project Configuration")]
#pragma warning disable CS0649
        [Tooltip("Toggle type of build: Server, Client or Host+Play")]
        [SerializeField] internal NetworkType networkType;
#pragma warning restore CS0649
        [Tooltip("Toggle debug mode for logging (globally, affects all components with a DebugHelper as well)")]
        public bool globalDebugMode;

        [Header("Security")]
        public string securitySalt = "16_or_more_bytes";

        [Header("Servers")]
        public ServerInfoTemplate[] serverList;

        [Header("Logging")]
        public bool logMode;
        [Tooltip("Filename for the text log file (zone and chat servers append a random suffix to this)")]
        public string logFilename = "NetGameLog";
        [Tooltip("Foldername for all text log files(normal found inside project folder or project package")]
        public string logFolder = "NetGameLogs";

        static ProjectConfigTemplate _instance;

        public static ProjectConfigTemplate singleton
        {
            get
            {
                if (!_instance)
                    _instance = Resources.FindObjectsOfTypeAll<ProjectConfigTemplate>().FirstOrDefault();
                return _instance;
            }
        }

        public NetworkType GetNetworkType
        {
            get
            {
                return networkType;
            }
        }

        public void OnValidate()
        {
#if UNITY_EDITOR
            if(networkType == NetworkType.Server)
            {
                EditorTools.RemoveScriptingDefine(Constants.BuildModeClient);
                EditorTools.AddScriptingDefine(Constants.BuildModeServer);
                DebugManager.Log("<b><color=yellow>[ProjectConfig] Switched to SERVER mode. </color></b>");
            }
            else if(networkType == NetworkType.HostAndPlay)
            {
                EditorTools.AddScriptingDefine(Constants.BuildModeClient);
                EditorTools.AddScriptingDefine(Constants.BuildModeServer);
                DebugManager.Log("<b><color=green>[ProjectConfig] Switched to HOST & PLAY mode. </color></b>");
            }
            else
            {
                EditorTools.AddScriptingDefine(Constants.BuildModeClient);
                EditorTools.RemoveScriptingDefine(Constants.BuildModeServer);
                DebugManager.Log("<b><color=blue>[ProjectConfig] Switched to CLIENT mode. </color></b>");
            }
#endif
        }
    }
}
