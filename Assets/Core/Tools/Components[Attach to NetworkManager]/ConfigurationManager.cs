using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace LangerNetwork
{
    [DisallowMultipleComponent]
    public partial class ConfigurationManager : MonoBehaviour
    {
        [Header("Templates (Unique/Singleton)")]
        public ProjectConfigTemplate projectConfigTemplate;
        public GameRulesTemplate gameRulesTemplate;
        public ServerAuthorityTemplate serverAuthorityTemplate;
    }
}
