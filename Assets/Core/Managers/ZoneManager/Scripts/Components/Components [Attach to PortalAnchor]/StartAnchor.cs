using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using LangerNetwork;
using LangerNetwork.Network;
using LangerNetwork.Database;
using LangerNetwork.Debugging;
using LangerNetwork.UI;

namespace LangerNetwork.Zones
{
    [DisallowMultipleComponent]
    public class StartAnchor : MonoBehaviour
    {
        [Tooltip("Add any number of achetypes who can start the game here")]
        public ArchetypeTemplate[] archetypes;

        public void Awake()
        {
            Invoke(nameof(AwakeLate), 0.1f);
        }

        void AwakeLate()
        {
            AnchorManager.singleton.RegisterStartAnchor(name, transform.position, archetypes);
        }

        public void OnDestroy()
        {
            if (AnchorManager.singleton)
                AnchorManager.singleton.UnRegisterStartAnchor(name);
        }
    }
}