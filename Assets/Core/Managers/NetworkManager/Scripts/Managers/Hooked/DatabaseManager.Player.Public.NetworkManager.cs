using LangerNetwork;
using LangerNetwork.Network;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace LangerNetwork.Database
{
    public partial class DatabaseManager
    {
        public List<PlayerPreview> GetPlayers(string username)
        {
            List<TablePlayer> results = Query<TablePlayer>("SELECT * FROM " + nameof(TablePlayer) + " WHERE username=? AND deleted=0 AND banned=0", username);
            List<PlayerPreview> players = new List<PlayerPreview>();
            if (results == null)
                return players;
            foreach (TablePlayer result in results)
                players.Add(new PlayerPreview { name = result.playername });
            return players;
        }
    }
}
