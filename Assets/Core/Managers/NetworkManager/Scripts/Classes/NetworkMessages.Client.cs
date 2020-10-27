using LangerNetwork;
using Mirror;

namespace LangerNetwork.Network
{
    public partial class ClientMessageRequest : MessageBase
    {
        public bool success;
        public string text;
    }

    public partial class ClientMessageRequestAuth : ClientMessageRequest
    {
        public string clientVersion;
    }

    public partial class CLientMessageRequestUserLogin : ClientMessageRequest
    {
        public string username;
        public string password;
    }

    public partial class ClientMessageRequestUserLogout : ClientMessageRequest
    { }

    public partial class ClientMessageRequestUserRegister : ClientMessageRequest
    {
        public string userName;
        public string password;
        public string email;
        public string deviceid;
    }

    public partial class ClientMessageRequestUserDelete : ClientMessageRequest
    {
        public string userName;
        public string password;
    }

    public partial class ClientMessageRequestUserChangePassword : ClientMessageRequest
    {
        public string userName;
        public string oldPassword;
        public string newPassword;
    }

    public partial class ClientMessageRequestUserConfirm : ClientMessageRequest
    {
        public string userName;
        public string password;
    }

    public partial class ClientMessageRequestPlayerLogin : ClientMessageRequest
    {
        public string userName;
        public string playerName;
    }

    public partial class ClientMessageRequestPlayerRegister : ClientMessageRequest
    {
        public string userName;
        public string playerName;
        public string prefabName;
    }

    public partial class ClientMessageRequestPlayerDelete : ClientMessageRequest
    {
        public string userName;
        public string playerName;
    }

}
