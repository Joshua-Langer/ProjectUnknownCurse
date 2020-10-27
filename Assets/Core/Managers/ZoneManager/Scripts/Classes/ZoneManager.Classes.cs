using System;
using UnityEngine;
using Mirror;
using LangerNetwork;

namespace LangerNetwork.Zones
{
    [Serializable]
    public partial class SceneLocation
    {
        public UnityScene scene;
        public Vector3 position;

        public bool Valid
        {
            get
            {
                return scene.IsSet();
            }
        }
    }

    public partial class PortalAnchorEntry
    {
        public string name;
        public Vector3 position;
    }

    public partial class StartAnchorEntry
    {
        public string name;
        public Vector3 position;
        public ArchetypeTemplate[] archeTypes;
    }
}
