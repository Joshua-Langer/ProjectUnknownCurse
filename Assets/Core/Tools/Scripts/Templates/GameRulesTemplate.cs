using System;
using UnityEngine;
using System.Linq;

namespace LangerNetwork
{
    [CreateAssetMenu(fileName = "New GameRules", menuName = "Net Game - Configuration/New GameRules", order = 999)]
    public partial class GameRulesTemplate : ScriptableObject
    {
        static GameRulesTemplate _instance;

        public static GameRulesTemplate singleton
        {
            get
            {
                if (!_instance)
                    _instance = Resources.FindObjectsOfTypeAll<GameRulesTemplate>().FirstOrDefault();
                return _instance;
            }
        }
    }
}
