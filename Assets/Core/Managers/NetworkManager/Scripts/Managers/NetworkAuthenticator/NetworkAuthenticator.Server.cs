using LangerNetwork;
using LangerNetwork.Network;
using LangerNetwork.Zones;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using Mirror;

namespace LangerNetwork.Network
{
    public partial class NetworkAuthenticator
    {
        public override void OnStartServer()
        {
            NetworkServer.RegisterHandler<ClientMessageRequestAuth>(OnClientMessageRequestAuth, false);
            this.InvokeInstanceDevExtMethods(nameof(OnStartServer));
        }

        public override void OnServerAuthenticate(NetworkConnection conn)
        {

        }

        void OnClientMessageRequest(NetworkConnection conn, ClientMessageRequest msg)
        {

        }

        void OnClientMessageRequestAuth(NetworkConnection conn, ClientMessageRequestAuth msg)
        {
            ServerMessageResponseAuth message = new ServerMessageResponseAuth
            {
                success = true,
                text = "",
                causesDisconnect = false
            };
            bool portalChecked = true;
            if (GetComponent<ZoneManager>() != null && !Getcomponent<ZoneManager>().GetIsMainZone)
                portalChecked = false;
            if((checkApplicationVersion && msg.clientVersion != Application.version) || !portalChecked)
            {
                message.text = systemText.versionMismatch;
                message.success = false;
            }
            else
            {
                base.OnServerAuthenticated.Invoke(conn);
                debug.LogFormat(this.name, nameof(OnClientMessageRequestAuth), conn.ID(), "Authenticated");
            }

            conn.Send(message);
            if(!message.success)
            {
                conn.isAuthenticated = false;
                conn.Disconnect();
                debug.LogFormat(this.name, nameof(OnClientMessageRequestAuth), conn.ID(), "DENIED");
            }    
        }

    }
}
