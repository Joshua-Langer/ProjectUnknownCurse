using LangerNetwork;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using Mirror;
using LangerNetwork.Zones;
using LangerNetwork.UI;

namespace LangerNetwork.Network
{
    public partial class NetworkAuthenticator
    {
        [Header("Client Settings")]
        public bool checkApplicationVersion = true;
        [Range(0, 99)]
        public int connectDelayMin = 4;
        [Range(0, 99)]
        public int connectDelayMax = 8;
        [Range(1, 999)]
        public int connectTimeout = 60;

        [HideInInspector] public int connectDelay;

        public override void OnStartClient()
        {
            NetworkClient.RegisterHandler<ServerMessageResponseAuth>(OnServerMessageResponseAuth, false);
            this.InvokeInstanceDevExtMethods(nameof(OnStartClient));
        }

        public override void OnClientAuthenticate(NetworkConnection conn)
        {
            if (GetComponent<ZoneManager>() != null && !GetComponent<ZoneManager>().GetAutoConnect)
                Invoke(nameof(ClientAuthenticate), connectDelay);

            this.InvokeInstanceDevExtMethods(nameof(OnClientAuthenticate), conn); //HOOK
        }

        public void ClientAuthenticate()
        {

            ClientMessageRequestAuth msg = new ClientMessageRequestAuth
            {
                clientVersion = Application.version
            };

            NetworkClient.Send(msg);

            debug.LogFormat(this.name, nameof(ClientAuthenticate)); //DEBUG
        }

        void OnServerMessageResponseAuth(NetworkConnection conn, ServerMessageResponseAuth msg)
        {

            // -- show popup if error message is not empty
            if (!String.IsNullOrWhiteSpace(msg.text))
                UIPopupConfirm.singleton.Init(msg.text);

            // -- disconnect and un-authenticate if anything went wrong
            if (!msg.success || msg.causesDisconnect)
            {
                conn.isAuthenticated = false;
                conn.Disconnect();
                NetworkManager.singleton.StopClient();

                debug.LogFormat(this.name, nameof(OnServerMessageResponseAuth), conn.ID(), "DENIED"); //DEBUG
            }

            // -- ready client
            if (msg.success && !msg.causesDisconnect)
            {
                CancelInvoke();
                base.OnClientAuthenticated.Invoke(conn);

                UIWindowAuth.singleton.Hide();
                UIWindowMain.singleton.Show();

                debug.LogFormat(this.name, nameof(OnServerMessageResponseAuth), conn.ID(), "Authenticated"); //DEBUG
            }

        }
    }
}
