using LangerNetwork;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using SQLite;

namespace LangerNetwork.Database
{
    public partial class DatabaseManager
    {
        [DevExtMethods(nameof(SavePlayers))]
        void SavePlayers_Network()
        {
            if (LangerNetwork.Network.NetworkManager.onlinePlayers.Count == 0)
                return;
            databaseLayer.BeginTransaction();
            foreach (GameObject player in LangerNetwork.Network.NetworkManager.onlinePlayers.Values)
                if (player != null)
                    SaveDataPlayer(player, false, false);
            databaseLayer.Commit();
            if (LangerNetwork.Network.NetworkManager.onlinePlayers.Count > 0)
                debug.LogFormat(this.name, nameof(SavePlayers_Network), LangerNetwork.Network.NetworkManager.onlinePlayers.Count.ToString());
        }
    }
}