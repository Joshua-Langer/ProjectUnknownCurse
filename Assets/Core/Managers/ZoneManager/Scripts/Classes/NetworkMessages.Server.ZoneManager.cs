using System.Collections.Generic;
using LangerNetwork;
using Mirror;

namespace LangerNetwork.Network
{
    public partial class ServerMessageResponsePlayerSwitchServer : ServerMessageResponse
    {
        public string playerName;
        public string anchorName;
        public string zoneName;
        public int token;
    }

    public partial class ServerMessageResponsePlayerAutoLogin : ServerMessageResponse
    { }

    public partial class ServerMessageResponseAutoAuth : ServerMessageResponse
    { }

}
