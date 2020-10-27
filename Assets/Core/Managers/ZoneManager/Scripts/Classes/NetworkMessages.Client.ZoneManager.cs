using LangerNetwork;
using Mirror;

namespace LangerNetwork.Network
{
    public partial class ClientMessageRequestPlayerSwitchServer : ClientMessageRequest
    {
        public string playerName;
        public string zoneName;
        public string anchorName;
        public int token;
    }

    public partial class ClientMessageRequestPlayerAutoLogin : ClientMessageRequest
    {
        public string userName;
        public string playerName;
        public int token;
    }

    public partial class ClientMessageRequestAutoAuth : ClientMessageRequest
    {
        public string clientVersion;
    }
}
