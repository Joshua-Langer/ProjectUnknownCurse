using LangerNetwork;
using LangerNetwork.Database;
using LangerNetwork.Debugging;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Mirror;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LangerNetwork.Network
{
    [RequireComponent(typeof(ConfigurationManager))]
    [RequireComponent(typeof(NetworkAuthenticator))]
    [DisallowMultipleComponent]
    public partial class NetworkManager : BaseNetworkManager
    {
        [Header("System Texts")]
        public NetworkManager_Lang systemText;
        [Header("Event Listeners")]
        public NetworkManager_Events eventListener;

        public static new NetworkManager singleton;

        public static Dictionary<string, GameObject> onlinePlayers = new Dictionary<string, GameObject>();
        protected Dictionary<NetworkConnection, string> onlineUsers = new Dictionary<NetworkConnection, string>();

        [HideInInspector] public string userName = "";
        [HideInInspector] public string userPassword = "";
        [HideInInspector] public string newPassword = "";
        [HideInInspector] public List<PlayerPreview> playerPreviews = new List<PlayerPreview>();
        [HideInInspector] public int maxPlayers = 0;

        [HideInInspector] public NetworkState state = NetworkState.Offline;

        public virtual void AwakePriority()
        {
            this.InvokeInstanceDevExtMethods(nameof(AwakePriority));
            debug.LogFormat(this.name, nameof(AwakePriority));
        }

        public override void Awake()
        {
            singleton = this;
            base.Awake();
            AwakePriority();
            Invoke(nameof(AwakeLate), 0.25f);
        }

        protected void AwakeLate()
        {
#if _SERVER && _CLIENT
            StartHost();
            debug.LogFormat(this.name, nameof(StartHost));
#elif _SERVER
            if (GetComponent<ZoneManager>() != null && GetComponent<ZoneManager>().GetIsMainZone)
			{
				StartServer();
				debug.LogFormat(this.name, nameof(StartServer)); //DEBUG
			}
#else
            StartClient();
            debug.LogFormat(this.name, nameof(StartClient));
#endif
			this.InvokeInstanceDevExtMethods(nameof(Awake));
        }

        public override void Start()
        {
            base.Start();
            this.InvokeInstanceDevExtMethods(nameof(Start));
        }

        void Update()
        {
            if (ClientScene.localPlayer != null)
                state = NetworkState.Game;
        }

		public bool GetIsUserLoggedIn(string userName)
		{

			bool online = false;

			// -- 1) lookup in dictionary of local server
			foreach (KeyValuePair<NetworkConnection, string> user in onlineUsers)
				if (user.Key != null && user.Value == userName)
					online = true;

			// -- 2) lookup in database if not online locally
			if (!online)
				online = DatabaseManager.singleton.GetUserOnline(userName);

			debug.LogFormat(this.name, nameof(GetIsUserLoggedIn), userName, online.ToString()); //DEBUG

			return online;
		}

		// -------------------------------------------------------------------------------
		// GetIsPlayerLoggedIn
		// -------------------------------------------------------------------------------
		public bool GetIsPlayerLoggedIn(string playerName)
		{

			bool online = false;

			// -- 1) lookup in dictionary of local server
			foreach (KeyValuePair<string, GameObject> player in onlinePlayers)
				if (player.Value != null && player.Value.name == playerName)
					online = true;

			// -- 2) lookup in database if not online locally
			if (!online)
				online = DatabaseManager.singleton.GetPlayerOnline(playerName);

			debug.LogFormat(this.name, nameof(GetIsPlayerLoggedIn), playerName, online.ToString()); //DEBUG

			return online;
		}

		// -------------------------------------------------------------------------------
		/// <summary>
		/// Public function <c>GetUserName</c> returns a String.
		/// Finds a players username based on their <c>NetworkConnection</c>.
		/// </summary>
		/// <param name="conn"></param>
		/// <returns> Returns the user's username </returns>
		public string GetUserName(NetworkConnection conn)
		{
			foreach (KeyValuePair<NetworkConnection, string> user in onlineUsers)
			{
				if (user.Key == conn)
				{
					debug.LogFormat(this.name, nameof(GetUserName), conn.ID(), user.Value); //DEBUG
					return user.Value;
				}
			}

			debug.LogFormat(this.name, nameof(GetUserName), conn.ID(), "NOT FOUND"); //DEBUG

			return "";

		}

		// -------------------------------------------------------------------------------
		/// <summary>
		/// Public method <c>ServerSendError</c>.
		/// Sends an error using the user's <c>NetworkConnection</c>.
		/// Can send the user a error sting and disconnect them. 
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="error"></param>
		/// <param name="disconnect"></param>
		public void ServerSendError(NetworkConnection conn, string error, bool disconnect)
		{
			conn.Send(new ServerMessageResponse { text = error, causesDisconnect = disconnect });
			debug.LogFormat(this.name, nameof(ServerSendError), conn.ID(), error); //DEBUG
		}

		// -------------------------------------------------------------------------------
		/// <summary>
		/// Public method <c>OnStopServer</c>.
		/// Closes the database connection.
		/// </summary>
		public override void OnStopServer()
		{

			// -- 1) saves all online players data
			DatabaseManager.singleton.SavePlayers();

			// -- Only in Host+Play as OnServerDisconnect does not get called:

			if (ProjectConfigTemplate.singleton.networkType == NetworkType.HostAndPlay)
			{

				// -- 2) force log-out out all online players
				if (onlinePlayers != null)
					foreach (KeyValuePair<string, GameObject> player in onlinePlayers.ToList())
						if (player.Value != null)
							OnServerDisconnect(player.Value.GetComponent<PlayerComponent>().connectionToClient);

			}

			// -- 3) closes the database connection
			DatabaseManager.singleton.Destruct();

			debug.LogFormat(this.name, nameof(OnStopServer)); //DEBUG
		}

		// -------------------------------------------------------------------------------
		/// <summary>
		/// Public function <c>IsConnecting</c> returns a boolean.
		/// Checks whether the client is active and the client scene is ready
		/// </summary>
		/// <returns> Returns a boolean value detailing whether the user is connecting </returns>
		public bool IsConnecting() => NetworkClient.active && !ClientScene.ready;

		// -------------------------------------------------------------------------------
		/// <summary>
		/// Public event <c>OnClientConnect</c>.
		/// Triggered when the client connects.
		/// </summary>
		/// <param name="conn"></param>
		public override void OnClientConnect(NetworkConnection conn)
		{
			this.InvokeInstanceDevExtMethods(nameof(OnClientConnect), conn); //HOOK
			debug.LogFormat(this.name, nameof(OnClientConnect), conn.ID()); //DEBUG
		}

		// -------------------------------------------------------------------------------
		/// <summary>
		/// Public event <c>OnServerConnect</c>.
		/// Triggered when the server receives a client connection.
		/// </summary>
		/// <param name="conn"></param>
		public override void OnServerConnect(NetworkConnection conn)
		{
			this.InvokeInstanceDevExtMethods(nameof(OnServerConnect), conn); //HOOK
			debug.LogFormat(this.name, nameof(OnServerConnect), conn.ID()); //DEBUG
		}

		// -------------------------------------------------------------------------------
		/// <summary>
		/// Public event <c>OnClientSceneChanged</c>.
		/// Triggered when the client's scene changed.
		/// </summary>
		/// <param name="conn"></param>
		public override void OnClientSceneChanged(NetworkConnection conn)
		{
			this.InvokeInstanceDevExtMethods(nameof(OnClientSceneChanged), conn); //HOOK
			debug.LogFormat(this.name, nameof(OnClientSceneChanged), conn.ID()); //DEBUG
		}

		// -------------------------------------------------------------------------------
		/// <summary>
		/// Public event <c>OnServerAddPlayer</c>.
		/// Triggered when the server adds a player.
		/// </summary>
		/// <param name="conn"></param>
		public override void OnServerAddPlayer(NetworkConnection conn)
		{
			this.InvokeInstanceDevExtMethods(nameof(OnServerAddPlayer), conn); //HOOK
			debug.LogFormat(this.name, nameof(OnServerAddPlayer), conn.ID()); //DEBUG
		}

		// -------------------------------------------------------------------------------
		/// <summary>
		/// Publice event <c>OnServerDisconnect</c>.
		/// Triggered on the server when a client disconnects.
		/// </summary>
		/// <param name="conn"></param>
		public override void OnServerDisconnect(NetworkConnection conn)
		{
			LogoutPlayerAndUser(conn);
			base.OnServerDisconnect(conn);
			debug.LogFormat(this.name, nameof(OnServerDisconnect), conn.ID()); //DEBUG
		}

		// -------------------------------------------------------------------------------
		// OnClientDisconnect
		// @Client
		// -------------------------------------------------------------------------------
		/// <summary>
		/// Public event <c>OnClientDisconnect</c>.
		/// Triggered when the client disconnects.
		/// Runs on the client.
		/// </summary>
		/// <param name="conn"></param>
		public override void OnClientDisconnect(NetworkConnection conn)
		{
			// -- required: otherwise a zone switch would disconnect the client
			if (GetComponent<ZoneManager>() != null && !GetComponent<ZoneManager>().GetAutoConnect)
			{
				base.OnClientDisconnect(conn);
				state = NetworkState.Offline;
				UIPopupConfirm.singleton.Init(systemText.clientDisconnected, Quit);
			}
			this.InvokeInstanceDevExtMethods(nameof(OnClientDisconnect)); //HOOK
			debug.LogFormat(this.name, nameof(OnClientDisconnect), conn.ID()); //DEBUG
		}

		// -------------------------------------------------------------------------------
		// Quit
		// universal quit function
		// -------------------------------------------------------------------------------
		/// <summary>
		/// Public method <c>Quit</c>.
		/// Universal Quit function.
		/// </summary>
		public void Quit()
		{
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}
