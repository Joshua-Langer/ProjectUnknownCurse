using UnityEngine;
using System;
using Mirror;
using System.Collections.Generic;
using LangerNetwork;
using LangerNetwork.Debugging;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LangerNetwork.Network
{
    public abstract partial class BaseNetworkManager: Mirror.NetworkManager
    {
        [Header("Debug Helper")]
        public DebugHelper debug = new DebugHelper();

        [Header("Spawnable Prefabs (use the template below - never edit the list in NetworkManager directly")]
        public SpawnablePrefabsTemplate spawnPrefabsTemplate;

        public override void Awake()
        {
            base.Awake();
            if(spawnPrefabsTemplate)
            {
                spawnPrefabs.Clear();
                spawnPrefabs.AddRange(spawnPrefabsTemplate.GetRegisteredSpawnablePrefabs);
            }
        }
    }
}