using System;
using LangerNetwork.Debugging;
using UnityEngine;

namespace LangerNetwork.Database
{
    public abstract partial class BaseDatabaseManager
    {
        public virtual bool TryPlayerAutoLogin(string playername, string username)
        {
            return (Tools.IsAllowedName(playername) && Tools.IsAllowedName(username));
        }

        public virtual bool TryPlayerSwitchServer(string playername, string anchorname, string zonename, int token)
        {
            return (Tools.IsAllowedName(playername) && !String.IsNullOrWhiteSpace(anchorname) && !String.IsNullOrWhiteSpace(zonename) && token >= 1000 && token <= 9999);
        }
    }
}