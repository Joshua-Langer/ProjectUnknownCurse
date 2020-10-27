using LangerNetwork;
using UnityEngine;
using System;
using Mirror;
using System.Collections.Generic;

namespace LangerNetwork.Network
{
    public abstract partial class BaseNetworkManager
    {
        protected abstract GameObject GetPlayerPrefab(string playerName);

        protected virtual bool RequestUserLogin(NetworkConnection conn, string userName, string password)
        {
            return (Tools.IsAllowedName(userName) && Tools.IsAllowedPassword(password));
        }

        protected virtual bool RequestUserLogout(NetworkConnection conn)
        {
            return (conn != null);
        }

        protected virtual bool RequestUserRegister(NetworkConnection conn, string userName, string password, string usermail)
        {
            return (Tools.IsAllowedName(userName) && Tools.IsAllowedPassword(password));
        }

        protected virtual bool RequestUserDelete(NetworkConnection conn, string userName, string password, int _action = 1)
        {
            return (Tools.IsAllowedName(userName) && Tools.IsAllowedPassword(password));
        }

        protected virtual bool RequestUserChangePassword(NetworkConnection conn, string username, string oldpassword, string newpassword)
        {
            return (Tools.IsAllowedName(username) && Tools.IsAllowedPassword(oldpassword) && Tools.IsAllowedPassword(newpassword) && oldpassword != newpassword);
        }

        protected virtual bool RequestUserConfirm(NetworkConnection conn, string username, string password, int _action = 1)
        {
            return (Tools.IsAllowedName(username) && Tools.IsAllowedPassword(password));
        }

        protected virtual bool RequestPlayerLogin(NetworkConnection conn, string playername, string username)
        {
            return (Tools.IsAllowedName(playername) && Tools.IsAllowedName(username));
        }

        protected virtual bool RequestPlayerRegister(NetworkConnection conn, string playername, string username, string prefabname)
        {
            return (Tools.IsAllowedName(playername) && Tools.IsAllowedName(username) && !String.IsNullOrWhiteSpace(prefabname));
        }

        protected virtual bool RequestPlayerDelete(NetworkConnection conn, string playername, string username, int _action = 1)
        {
            return (Tools.IsAllowedName(playername) && Tools.IsAllowedName(username));
        }
    }
}