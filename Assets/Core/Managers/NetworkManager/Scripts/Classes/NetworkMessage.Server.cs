using System.Collections.Generic;
using LangerNetwork;
using Mirror;

namespace LangerNetwork.Network
{
    public partial class ServerMessageResponse : MessageBase
    {
        public bool success;
        public string text;
        public bool causesDisconnect;
    }

    public partial class ServerMessageResponseAuth : ServerMessageResponse
    {

    }

    public partial class ServerMessageResponseUserLogin : ServerMessageResponseUserPlayerPreviews
    {

    }

    public partial class ServerMessageResponseUserRegister : ServerMessageResponse
    { }

    public partial class ServerMessageResponseUserDelete : ServerMessageResponse
    { }

    public partial class ServerMessageResponseUserChangePassword : ServerMessageResponse
    { }

    public partial class ServerMessageResponseUserConfirm : ServerMessageResponse
    { }

    public partial class ServerMessageResponseUserPlayerPreviews : ServerMessageResponse
    {
        public PlayerPreview[] players;
        public int maxPlayers;

        public void LoadPlayerPreview(List<PlayerPreview> _players)
        {
            players = new PlayerPreview[_players.Count];
            players = _players.ToArray();
        }
    }

    public partial class ServerMessageResponsePlayerLogin : ServerMessageResponse
    { }

    public partial class ServerMessageResponsePlayerRegister : ServerMessageResponse
    {
        public string playerName;
    }

    public partial class ServerMessageResponsePlayerDelete : ServerMessageResponse
    { }

}
