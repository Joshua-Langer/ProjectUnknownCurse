using Mirror;

namespace LangerNetwork.Network
{
    public partial class NetworkManager
    {
        public void TryAutoLoginPlayer(string playerName, int token)
        {
            RequestPlayerAutoLogin(NetworkClient.connection, playerName, userName, token);
        }
    }
}