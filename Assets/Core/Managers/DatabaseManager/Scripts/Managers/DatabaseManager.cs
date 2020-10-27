using LangerNetwork;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using SQLite;

namespace LangerNetwork.Database
{
    [DisallowMultipleComponent]
    public partial class DatabaseManager : BaseDatabaseManager, IAbstractableDatabase
    {
        [Header("Settings")]
        public DatabaseAbstractionLayer databaseLayer;
        [Tooltip("Player data save interval in seconds (0 to disable).")]
        public float saveInterval = 60f;
        [Tooltip("Deleted user prune interval in seconds (0 to disable).")]
        public float deleteInterval = 240f;
        [Tooltip("Allow relogin after client inactivity in seconds (should be saveInterval or more).")]
        public float logoutInterval = 90f;

        public static DatabaseManager singleton;

        void OnEnable()
        {
            OnValidate();
        }

        void OnValidate()
        {
            if (databaseLayer)
                databaseLayer.OnValidate();
        }

        void DeleteUsers()
        {
            this.InvokeInstanceDevExtMethods(nameof(DeleteUsers));
            debug.Log("[" + name + "] Invoking: DeleteUsers"); //DEBUG
        }

        public void SavePlayers()
        {
            this.InvokeInstanceDevExtMethods(nameof(SavePlayers));
            debug.Log("[" + name + "] Invoking: SavePlayers"); //DEBUG
        }
    }
}