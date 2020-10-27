using UnityEngine;

namespace LangerNetwork.UI
{
    public abstract partial class UIRoot
    {
        protected GameObject _localPlayer = null;

        protected GameObject localPlayer
        {
            get
            {
                if (_localPlayer == null)
                    _localPlayer = PlayerComponent.localPlayer;
                return _localPlayer;
            }
        }
    }
}
