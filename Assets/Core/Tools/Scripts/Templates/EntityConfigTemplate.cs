using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//Network
using LangerNetwork.Debugging;

namespace LangerNetwork
{
    [CreateAssetMenu(fileName = "New Entity Configuration", menuName = "Net Game - Configuration/New Entity Configuration", order = 999)]
    public partial class EntityConfigTemplate : ScriptableObject
    {
        static EntityConfigTemplate _instance;

        public static EntityConfigTemplate singleton
        {
            get
            {
                if (!_instance)
                    _instance = Resources.FindObjectsOfTypeAll<EntityConfigTemplate>().FirstOrDefault();
                return _instance;
            }
        }
    }
}
