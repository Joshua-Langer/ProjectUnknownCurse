using LangerNetwork;
using LangerNetwork.UI;
using LangerNetwork.Network;
using UnityEngine;

namespace LangerNetwork.UI
{

	// ===================================================================================
	// UIRoot
	// ===================================================================================
	public abstract partial class UIRoot
	{

		protected Network.NetworkManager _networkManager = null;
		protected Network.NetworkAuthenticator _networkAuthenticator = null;

		// -------------------------------------------------------------------------------
		// networkManager
		// -------------------------------------------------------------------------------
		protected Network.NetworkManager networkManager
		{
			get
			{
				if (_networkManager == null)
					_networkManager = FindObjectOfType<Network.NetworkManager>();
				return _networkManager;
			}
		}

		// -------------------------------------------------------------------------------
		// networkAuthenticator
		// -------------------------------------------------------------------------------
		protected Network.NetworkAuthenticator networkAuthenticator
		{
			get
			{
				if (_networkAuthenticator == null)
					_networkAuthenticator = FindObjectOfType<Network.NetworkAuthenticator>();
				return _networkAuthenticator;
			}
		}

	}

}

// =======================================================================================