using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Mirror;
using LangerNetwork.Database;
using UnityEngine.AI;

namespace LangerNetwork
{
    public partial class PlayerComponent
    {
        [Header("Base Cooldown for 'risky actions' (in seconds)")]
        [Range(1, 999)] public double baseCooldown;

        [SyncVar] double cooldown = 0;

        public bool CheckCooldown
        {
            get
            {
                return NetworkTime.time >= cooldown;
            }
        }

        [Command]
        public void Cmd_UpdateCooldown(float extraCooldown)
        {
            UpdateCooldown(extraCooldown);
        }

        [Server]
        protected void UpdateCooldown(float extraCooldown)
        {
            cooldown = NetworkTime.time + (float)(baseCooldown + Mathf.Abs(extraCooldown));
            tablePlayer.cooldown = GetCooldownTimeRemaining();
        }

        public float GetCooldownTimeRemaining()
        {
            return CheckCooldown ? 0 : (float)(cooldown - NetworkTime.time);
        }
    }
}
