using LangerNetwork;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using Mirror;
using LangerNetwork.UI;

namespace LangerNetwork.Network
{
    [RequireComponent(typeof(LangerNetwork.Network.NetworkManager))]
    [DisallowMultipleComponent]
    public partial class NetworkAuthenticator : BaseNetworkAuthenticator
    {
        [Header("System Texts")]
        public NetworkAuthenticator_Lang systemText;
        public static NetworkAuthenticator singleton;

        public override void Awake()
        {
            base.Awake();
            singleton = this;
            connectDelay = UnityEngine.Random.Range(connectDelayMin, connectDelayMax);
        }
    }
}