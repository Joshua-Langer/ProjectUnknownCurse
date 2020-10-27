using LangerNetwork;
using LangerNetwork.Debugging;
using UnityEngine;
using System;
using Mirror;
using System.Collections.Generic;

namespace LangerNetwork.Network
{
    public abstract partial class BaseNetworkAuthenticator : NetworkAuthenticator
    {
        [Header("Debug Helper")]
        public DebugHelper debug = new DebugHelper();

        public virtual void Awake()
        {

        }
    }
}