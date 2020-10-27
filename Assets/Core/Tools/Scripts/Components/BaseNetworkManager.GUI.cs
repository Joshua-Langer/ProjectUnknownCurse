using UnityEngine;
using System.Collections;
using UnityEditor;

namespace LangerNetwork
{
#if UNITY_EDITOR
    //spawnable prefabs template editor
    [CustomEditor(typeof(SpawnablePrefabsTemplate))]
    public class SpawnablePrefabsTemplateEditor : Editor
    {
        //OnInspectorGUI
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            SpawnablePrefabsTemplate template = (SpawnablePrefabsTemplate)target;
            if(GUILayout.Button("Search & add Prefabs"))
            {
                template.AutoRegisterSpawnablePrefabs();
            }
        }
    }
#endif
}


