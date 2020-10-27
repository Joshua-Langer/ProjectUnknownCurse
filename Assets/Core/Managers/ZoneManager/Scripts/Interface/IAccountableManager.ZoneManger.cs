using System;
using UnityEngine;
using LangerNetwork;

namespace LangerNetwork.Database
{
    public partial interface IAccountableManager
    {
        bool TryPlayerSwitchServer(string playername, string anchorname, string zonename, int token);
    }
}

