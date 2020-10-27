using System;
using UnityEngine;

namespace LangerNetwork.Zones
{
    [DisallowMultipleComponent]
    public class ZoneAnchor : MonoBehaviour
    {
        public void Awake()
        {
            Invoke(nameof(AwakeLate), 0.1f);
        }

        void AwakeLate()
        {
            AnchorManager.singleton.RegisterPortalAnchor(name, transform.position);
        }

        public void OnDestroy()
        {
            if (AnchorManager.singleton)
                AnchorManager.singleton.UnRegisterPortalAnchor(name);
        }
    }
}
