using LangerNetwork;
using System;
using SQLite;
using UnityEngine;

namespace LangerNetwork.Database
{
    public partial class TablePlayerZones
    { 
        [PrimaryKey]
        public string playerName { get; set; }
        public string zoneName { get; set; }
        public string anchorName { get; set; }
        public bool startPos { get; set; }
        public int token { get; set; }

        public bool ValidateToken(int _token)
        {
            return (token == _token);
        }
    }

    public partial class TableNetworkZones
    {
        [PrimaryKey]
        public string zone { get; set; }
        public DateTime online { get; set; }
    }

}