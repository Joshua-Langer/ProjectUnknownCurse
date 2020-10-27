using LangerNetwork;
using Mirror;

namespace LangerNetwork.Network
{
    public abstract partial class BaseNetworkBehaviour : NetworkBehaviour
    {
        protected string _name;

        public new string name
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_name))
                    _name = base.name;
                return _name;
            }
            set
            {
                _name = base.name = value;
            }
        }
    }
}