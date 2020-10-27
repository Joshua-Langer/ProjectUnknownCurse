using LangerNetwork.Debugging;
//USING NETWORK
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using SQLite;

namespace LangerNetwork.Database
{
    public partial class DatabaseManager
    {
        public override void Awake()
        {
            base.Awake();
            singleton = this;
#if _SERVER
            Init();
#endif
        }

        public void Init()
        {
            OpenConnection();
            databaseLayer.Init();
            this.InvokeInstanceDevExtMethods(nameof(Init));
            if(saveInterval > 0)
            {
                InvokeRepeating(nameof(SavePlayers), saveInterval, saveInterval);
                debug.Log("[" + name + "] Invoke Repeating: SavePlayers every " + saveInterval + " seconds");
            }
            if(deleteInterval > 0)
            {
                InvokeRepeating(nameof(DeleteUsers), deleteInterval, deleteInterval);
                debug.Log("[" + name + "] Invoke Repeating: DeleteUsers every " + deleteInterval + " seconds");
            }
            this.InvokeInstanceDevExtMethods(nameof(Init));
        }

        public void Destruct()
        {
            CancelInvoke();
            CloseConnection();
        }

        public void OpenConnection()
        {
            databaseLayer.OpenConnection();
            debug.Log("[" + name + "] OpenConnection");
        }

        public void CloseConnection()
        {
            databaseLayer.CloseConnection();
            debug.Log("[" + name + "] CloseConnection");
        }

        public void CreateTable<T>()
        {
            databaseLayer.CreateTable<T>();
            debug.Log("[" + name + "] CreateTable: " + typeof(T));
        }

        public void CreateIndex(string tableName, string[] columnNames, bool unique = false)
        {
            databaseLayer.CreateIndex(tableName, columnNames, unique);
            debug.Log("[" + name + "] CreateIndex: " + tableName + " (" + string.Join("_", columnNames) + ")");
        }

        public List<T> Query<T>(string query, params object[] args) where T : new()
        {
            debug.Log("[" + name + "] Query: " + typeof(T) + "(" + query + ")");
            return databaseLayer.Query<T>(query, args);
        }

        public void Execute(string query, params object[] args)
        {
            databaseLayer.Execute(query, args);
            debug.Log("[" + name + "] Execute: " + query);
        }

        public T FindWithQuery<T>(string query, params object[] args) where T : new()
        {
            debug.Log("[" + name + "] FindWithQuery: " + typeof(T) + " (" + query + ")");
            return databaseLayer.FindWithQuery<T>(query, args);
        }

        public void Insert(object obj)
        {
            databaseLayer.Insert(obj);
            debug.Log("[" + name + "] Insert: " + obj);
        }

        public void InsertOrReplace(object obj)
        {
            databaseLayer.InsertOrReplace(obj);
            debug.Log("[" + name + "] InsertOrReplace: " + obj);
        }

        public void BeginTransaction()
        {
            databaseLayer.BeginTransaction();
            debug.Log("[" + name + "] BeginTransaction");
        }

        public void Commit()
        {
            databaseLayer.Commit();
            debug.Log("[" + name + "] Commit");
        }
    }
}