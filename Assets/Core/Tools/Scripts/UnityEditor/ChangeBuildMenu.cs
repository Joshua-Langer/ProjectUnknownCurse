#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using LangerNetwork.Network;
using LangerNetwork.Zones;

namespace LangerNetwork
{

	// ===================================================================================
	// ChangeBuildMenu
	// ===================================================================================
	public class ChangeBuildMenu
	{

		// -------------------------------------------------------------------------------
		// SetBuildType
		// -------------------------------------------------------------------------------
		public static void SetBuildType(NetworkType buildType, bool headless = false)
		{
			ProjectConfigTemplate.singleton.networkType = buildType;
			ProjectConfigTemplate.singleton.OnValidate();

			EditorUserBuildSettings.enableHeadlessMode = headless;

			if (PlayerSettings.GetApiCompatibilityLevel(BuildTargetGroup.Standalone) != ApiCompatibilityLevel.NET_4_6)
			{
				Debug.Log("<color=orange><b>NetGame requires .NET 4.x</b></color>\n<b>Changing to .NET 4.x</b>"); //DEBUG
				PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Standalone, ApiCompatibilityLevel.NET_4_6);
			}
		}

		// -------------------------------------------------------------------------------
		// SetServer
		// -------------------------------------------------------------------------------
		[MenuItem("NetGame/Change Build/Server Mode", priority = 1)]
		public static void SetServer()
		{
			SetBuildType(NetworkType.Server, true);
			//ProjectConfigTemplate.singleton.networkType = NetworkType.Server;
			//ProjectConfigTemplate.singleton.OnValidate();
		}

		// -------------------------------------------------------------------------------
		// SetClient
		// -------------------------------------------------------------------------------
		[MenuItem("NetGame/Change Build/Client Mode", priority = 2)]
		public static void SetClient()
		{
			SetBuildType(NetworkType.Client);
			//ProjectConfigTemplate.singleton.networkType = NetworkType.Client;
			//ProjectConfigTemplate.singleton.OnValidate();
		}

		// -------------------------------------------------------------------------------
		// SetHostAndPlay
		// -------------------------------------------------------------------------------
		[MenuItem("NetGame/Change Build/Host and Play Mode", priority = 3)]
		public static void SetHostAndPlay()
		{
			SetBuildType(NetworkType.HostAndPlay);
			//ProjectConfigTemplate.singleton.networkType = NetworkType.HostAndPlay;
			//ProjectConfigTemplate.singleton.OnValidate();
		}

		// -------------------------------------------------------------------------------

	}

}
#endif