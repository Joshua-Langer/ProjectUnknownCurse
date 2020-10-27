using UnityEngine;
using UnityEngine.Events;
using LangerNetwork;
using System;

namespace LangerNetwork.Network
{
    [Serializable]
    public partial class NetworkManager_Events
    {
        public UnityEvent OnStartServer;
        public UnityEvent OnStopServer;
        public UnityEvent OnStartClient;
        public UnityEvent OnStopClient;
        public UnityEventConnection OnLoginPlayer;
        public UnityEventConnection OnLogoutPlayer;
    }
}