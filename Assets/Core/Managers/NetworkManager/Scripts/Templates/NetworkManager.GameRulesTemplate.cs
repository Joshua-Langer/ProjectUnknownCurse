using System;
using UnityEngine;

namespace LangerNetwork
{
    public partial class GameRulesTemplate
    {
        [Header("Player/User Settings")]
        [Tooltip("How many characters can one user create on one account")]
        public int maxPlayersPerUser = 4;
        [Tooltip("How many accounts per device")]
        public int maxUsersPerDevice = 4;
        [Tooltip("How many accounts per email")]
        public int maxUsersPerEmail = 4;
    }
}

