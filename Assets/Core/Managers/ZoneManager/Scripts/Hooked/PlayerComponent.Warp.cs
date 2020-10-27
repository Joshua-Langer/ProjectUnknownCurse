using Mirror;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using LangerNetwork.Network;
using LangerNetwork.Zones;
using LangerNetwork.Database;
using LangerNetwork.Debugging;

namespace LangerNetwork
{
    public partial class PlayerComponent
    {
        [Header("NetworkZones")]
        public NetworkZoneTemplate startingZone;
        protected int securityToken = 0;

        public int GetToken
        {
            get
            {
                return securityToken;
            }
        }

        public NetworkZoneTemplate currentZone
        {
            get
            {
                if (SceneManager.GetActiveScene() != null)
                    return NetworkZoneTemplate.GetZoneBySceneName(SceneManager.GetActiveScene().name);
                else
                    return startingZone;
            }
        }

        [Command]
        public void Cmd_WarpLocal(string anchorName)
        {
            WarpLocal(anchorName);
        }

        [Client]
        public void WarpRemote(string anchorName, string zoneName)
        {
            ZoneManager.singleton.RefreshToken();
            Cmd_WarpRemote(anchorName, zoneName, ZoneManager.singleton.GetToken);
        }

        [Command]
        protected void Cmd_WarpRemote(string anchorName, string zoneName, int token)
        {
            if (!String.IsNullOrWhiteSpace(anchorName) && !String.IsNullOrWhiteSpace(zoneName))
                WarpRemote(anchorName, zoneName, token);
        }

        [ServerCallback]
        public void WarpRemote(string anchorName, string zoneName, int token = 0)
        {
            UpdateCooldown(GameRulesTemplate.singleton.remoteWarpDelay);

            NetworkZoneTemplate template = NetworkZoneTemplate.GetZoneBySceneName(zoneName);

            // -- update anchor & zone
            this.GetComponent<PlayerComponent>().tablePlayerZones.anchorname = anchorName;
            this.GetComponent<PlayerComponent>().tablePlayerZones.zonename = zoneName;
            securityToken = token; // token must not be set in table, can be fetched via GetToken

            // -- save player
            DatabaseManager.singleton.SaveDataPlayer(this.gameObject);

            NetworkManager.singleton.SwitchServerPlayer(this.connectionToClient, this.gameObject.name, anchorName, zoneName, securityToken);

            NetworkServer.Destroy(this.gameObject);

            DebugManager.LogFormat(this.name, nameof(WarpRemote), zoneName, anchorName); //DEBUG
        }

        [ServerCallback]
        public void WarpLocal(string anchorName)
        {
            UpdateCooldown(GameRulesTemplate.singleton.localWarpDelay);

            if (AnchorManager.singleton.CheckPortalAnchor(anchorName))
                base.Warp(AnchorManager.singleton.GetPortalAnchorPosition(anchorName));

            if (AnchorManager.singleton.CheckStartAnchor(anchorName))
                base.Warp(AnchorManager.singleton.GetStartAnchorPosition(anchorName));
        }
    }
}
