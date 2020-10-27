using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace LangerNetwork
{
    [CreateAssetMenu(fileName = "Net NetworkZone", menuName = "Net Game - Servers/New Network Zone", order = 999)]
    public partial class NetworkZoneTemplate : ScriptableTemplate
    {
        [Header("Network Zone")]
        public ServerInfoTemplate server;
        public UnityScene scene;

        [Tooltip("Times out after zoneIntervalMain * zoneTimeoutMuliplier (in seconds, 0 to disable)")]
        public int zoneTimeoutMultiplier = 6;

        public static string _folderName = "";
        static NetworkZoneTemplateDictionary _data;

        public static NetworkZoneTemplate GetZoneBySceneName(string name)
        {
            foreach(KeyValuePair<int, NetworkZoneTemplate> template in data)
            {
                if (template.Value.scene != null && template.Value.scene.SceneName == name)
                    return template.Value;
            }
            return null;
        }

        public static ReadOnlyDictionary<int, NetworkZoneTemplate> data
        {
            get
            {
                NetworkZoneTemplate.BuildCache();
                return _data.data;
            }
        }

        public static void BuildCache(bool forced = false)
        {
            if (_data == null || forced)
                _data = new NetworkZoneTemplateDictionary(NetworkZoneTemplate._folderName);
        }

        public void OnEnable()
        {
            if (_folderName != folderName)
                _folderName = folderName;
            _data = null;
        }

        public override void OnValidate()
        {
            base.OnValidate();
        }
    }
}
