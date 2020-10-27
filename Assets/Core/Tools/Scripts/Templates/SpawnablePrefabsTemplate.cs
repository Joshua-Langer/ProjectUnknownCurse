using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LangerNetwork.Debugging;
using Mirror;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LangerNetwork
{
    [CreateAssetMenu(fileName = "New SpawnablePrefabs", menuName = "NetGame - Template/New SpawnablePrefabs", order = 999)]
    public partial class SpawnablePrefabsTemplate : ScriptableObject
    {
        [Header("Prefabs (Add manually)")]
        public List<GameObject> manualPrefabs;
        [Header("Prefabs (Added via button below")]
        public List<GameObject> autoPrefabs;

        [Header("Spawnable Prefab Filters")]
        [Tooltip("Exlude all prefabs in this list")]
        public List<GameObject> exludePrefabs;

        [Tooltip("Only prefabs of the listed categories are included")]
        public string[] categoryTags;

        [Header("Spawnable Prefabs Folders")]
        [Tooltip("Adding spawnable prefabs to network manager will only search in the folders below")]
        public string[] spawnablePrefabFolders;

        public List<GameObject> GetRegisteredSpawnablePrefabs
        {
            get
            {
                List<GameObject> spawnPrefabs = new List<GameObject>();
                spawnPrefabs.AddRange(manualPrefabs);
                spawnPrefabs.AddRange(autoPrefabs);

                return spawnPrefabs;
            }
        }
#if UNITY_EDITOR

        public void AutoRegisterSpawnablePrefabs()
        {
            var guids = AssetDatabase.FindAssets("t:Prefab", spawnablePrefabFolders);
            List<GameObject> toSelect = new List<GameObject>();

            autoPrefabs = new List<GameObject>();
            autoPrefabs.Clear();

            foreach(var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                UnityEngine.Object[] toCheck = AssetDatabase.LoadAllAssetsAtPath(path);

                foreach(UnityEngine.Object obj in toCheck)
                {
                    var go = obj as GameObject;

                    if (go == null || exludePrefabs.Contains(go))
                        continue;
                    NetworkIdentity ni = go.GetComponent<NetworkIdentity>();

                    if(ni != null)
                    {
                        EntityComponent entityComponent = go.GetComponent<EntityComponent>();

                        if (entityComponent == null || categoryTags == null || categoryTags.Length == 0)
                            toSelect.Add(go);
                        else if (Tools.ArrayContains(categoryTags, entityComponent.archeType.sortCategory))
                            toSelect.Add(go);
                    }
                }
            }
            autoPrefabs.AddRange(toSelect.ToArray());
            DebugManager.Log("[NetworkManager] Added [" + toSelect.Count + "] prefabs to spawnables prefabs list.");
        }
#endif
    }
}
