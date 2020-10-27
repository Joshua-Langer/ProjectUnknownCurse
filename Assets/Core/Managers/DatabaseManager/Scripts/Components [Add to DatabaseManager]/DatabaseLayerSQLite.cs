using LangerNetwork.Debugging;
using LangerNetwork;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace LangerNetwork.Database
{

    [Serializable]
    public partial class DatabaseLayerSQLite : DatabaseAbstractionLayer
    {
        [Header("Options")]
        public string databaseName = "DatabaseNetGame.sqlite";
        protected SQLiteConnection connection = null;
        protected static string _dbPath = "";

        public override void Init() { }

        public override void OpenConnection()
        {
            if (connection != null) return;
            _dbPath = Tools.GetPath(databaseName);
            connection = new SQLiteConnection(_dbPath);
        }

        public override void CloseConnection()
        {
            connection?.Close();
        }

        public override void CreateTable<T>()
        {
            connection.CreateTable<T>();
        }

        public override void CreateIndex(string tableName, string[] columnNames, bool unique = false)
        {
            connection.CreateIndex(tableName, columnNames, unique);
        }

        public override List<T> Query<T>(string query, params object[] args)
        {
            return connection.Query<T>(query, args);
        }

        public override void Execute(string query, params object[] args)
        {
            connection.Execute(query, args);
        }

        public override T FindWithQuery<T>(string query, params object[] args)
        {
            return connection.FindWithQuery<T>(query, args);
        }

        public override void Insert(object obj)
        {
            connection.Insert(obj);
        }

        public override void InsertOrReplace(object obj)
        {
            connection.InsertOrReplace(obj);
        }

        public override void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        public override void Commit()
        {
            connection.Commit();
        }

        public override void OnValidate() { }
    }
}