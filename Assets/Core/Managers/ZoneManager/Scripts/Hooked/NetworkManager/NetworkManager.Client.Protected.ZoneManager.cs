using LangerNetwork.Zones;
using Mirror;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using LangerNetwork;

namespace LangerNetwork.Network
{
    public partial class NetworkManager
    {
        [DevExtMethods(nameof(OnStartClient))]
        void OnStartClient_NetworkPortals()
        {
            NetworkClient.RegisterHandler<ServerMessageResponsePlayerSwitchServer>(GetComponent<ZoneManager>().OnServerMessageResponsePlayerSwitchServer);
            NetworkClient.RegisterHandler<ServerMessageResponsePlayerAutoLogin>(GetComponent<ZoneManager>().OnServerMessageResponsePlayerAutoLogin);
        }

        protected bool RequestPlayerAutoLogin(NetworkConnection conn, string playerName, string userName, int _token)
        {
            if (!base.RequestPlayerLogin(conn, playerName, userName))
                return false;
            ClientMessageRequestPlayerAutoLogin message = new ClientMessageRequestPlayerAutoLogin
            {
                playerName = playerName,
                userName = userName,
                token = _token
            };

            conn.Send(message);
            return true;
        }
    }
}