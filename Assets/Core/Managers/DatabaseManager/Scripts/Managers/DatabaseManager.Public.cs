using LangerNetwork;
//TODO: Add NETWORK to any script that still needs it in the using declarations
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using Mirror;

namespace LangerNetwork.Database
{
    public partial class DatabaseManager
    {
        public void CreateDefaultDataPlayer(GameObject player)
        {
            this.InvokeInstanceDevExtMethods(nameof(CreateDefaultDataPlayer), player);
        }

        public virtual void LoadDataPlayerPriority(GameObject player)
        {
            this.InvokeInstanceDevExtMethods(nameof(LoadDataPlayerPriority), player);
        }

        public GameObject LoadDataPlayer(GameObject prefab, string _name)
        {
            GameObject player = Instantiate(prefab);
            player.name = _name;
            LoadDataPlayerPriority(prefab, player);
            this.InvokeInstanceDevExtMethods(nameof(LoadDataPlayer), player);
            return player;
        }

        public void SaveDataUser(string username, bool isNew = false, bool useTransaction = true)
        {
            if (useTransaction)
                databaseLayer.BeginTransaction();
            this.InvokeInstanceDevExtMethods(nameof(SaveDataUser), username, isNew);
            if (useTransaction)
                databaseLayer.Commit();
        }

        public void SaveDataPlayer(GameObject player, bool isNew = false, bool useTransaction = true)
        {
            if (useTransaction)
                databaseLayer.BeginTransaction();
            this.InvokeInstanceDevExtMethods(nameof(SaveDataPlayer), player, isNew);
            if (useTransaction)
                databaseLayer.Commit();
        }

        public void LoginUser(string name)
        {
            this.InvokeInstanceDevExtMethods(nameof(LoginUser), name);
        }

        public void LogoutUser(string name)
        {
            SaveDataUser(name, false);
            this.InvokeInstanceDevExtMethods(nameof(LogoutUser), name);
        }

        public void LoginPlayer(NetworkConnection conn, GameObject player, string playerName, string userName)
        {
            this.InvokeInstanceDevExtMethods(nameof(LoginPlayer), conn, player, playerName, userName);
        }

        public void LogoutPlayer(GameObject player)
        {
            SaveDataPlayer(player, false);
            this.InvokeInstanceDevExtMethods(nameof(LogoutPlayer), player);
        }
    }
}