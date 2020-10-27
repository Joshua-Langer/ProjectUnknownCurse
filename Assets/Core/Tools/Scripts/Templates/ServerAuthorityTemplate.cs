using UnityEngine;
using System.Linq;

namespace LangerNetwork
{
    [CreateAssetMenu(menuName = "NetGame - Configuration/New Server Authority")]
    public partial class ServerAuthorityTemplate : ScriptableObject
    {
        [Header("SERVER SIDE AUTHORITY - movement")]
        [Tooltip("The level of validation to player movement desired." +
            "\nComplete: Validates the entire transform - Warps the player instantly back in position if they stay."
            + "Tolerant: Validates (only) position with tolerance factored in - can return the player to the destined position smoothly. - preferred"
            + "Low: Just validates position and nothing else.")]
        [SerializeField] public ValidationLevel validation = ValidationLevel.Complete;
        [Tooltip("When using Tolerant validation, a value will be tolerated if it is out of range by up to this amount in each direction.")]
        [SerializeField] public float tolerence = 7f;
        [Tooltip("Smoothly Moveback to the server dictated position.")]
        [SerializeField] public bool smooth = true;
        [Tooltip("How quickly the server will smooth player movement.")]
        [SerializeField] public float smoothing = 1f;

        static ServerAuthorityTemplate _instance;

        public static ServerAuthorityTemplate singleton
        {
            get
            {
                if (!_instance)
                    _instance = Resources.FindObjectsOfTypeAll<ServerAuthorityTemplate>().FirstOrDefault();
                return _instance;
            }
        }
    }
}
