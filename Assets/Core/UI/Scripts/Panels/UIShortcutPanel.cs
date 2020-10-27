using UnityEngine;
using LangerNetwork;
using LangerNetwork.UI;
using LangerNetwork.Network;

namespace LangerNetwork.UI
{

	// ===================================================================================
	// UIShortcutPanel
	// ===================================================================================
	public partial class UIShortcutPanel : UIRoot
	{

		// -------------------------------------------------------------------------------
		// ThrottledUpdate
		// -------------------------------------------------------------------------------
		protected override void ThrottledUpdate()
		{

			if (!networkManager || networkManager.state != NetworkState.Game)
				Hide();
			else
				Show();

		}

		// -------------------------------------------------------------------------------

	}

}
