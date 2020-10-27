using LangerNetwork;
using Mirror;

namespace LangerNetwork.Network
{
    public partial class NetworkName : BaseNetworkBehaviour
    {
        public override bool OnSerialize(NetworkWriter writer, bool initialState)
        {
            writer.WriteString(name);
            return true;
        }

        public override void OnDeserialize(NetworkReader reader, bool initialState)
        {
            name = reader.ReadString();
        }
    }
}