﻿
using LangerNetwork;
using LangerNetwork.Network;
using LangerNetwork.Database;
using LangerNetwork.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Mirror;

namespace LangerNetwork.Network
{

	// ===================================================================================
	// NetworkManager
	// ===================================================================================
	public partial class NetworkManager
	{

		[Header("GUI Scene")]
		public UnityScene guiScene;

		// -------------------------------------------------------------------------------
		// Awake
		// -------------------------------------------------------------------------------
		[DevExtMethods(nameof(AwakePriority))]
		void AwakePriority_UI()
		{
#if _CLIENT

			// -- load the UI scene only if we are client & UI available
			LoadUIAdditive();

#endif
		}

		// -------------------------------------------------------------------------------
		// LoadUIAdditive
		// -------------------------------------------------------------------------------
		protected void LoadUIAdditive()
		{
			if (guiScene != null)
				SceneManager.LoadScene(guiScene, LoadSceneMode.Additive);
		}

		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================