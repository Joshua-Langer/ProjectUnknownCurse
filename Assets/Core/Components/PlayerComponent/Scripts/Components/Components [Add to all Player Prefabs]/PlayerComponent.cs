using UnityEngine;
using Mirror;
using LangerNetwork.Database;
using System;

namespace LangerNetwork
{
    [DisallowMultipleComponent]
    [Serializable]
    public partial class PlayerComponent : EntityComponent
    {
        public TablePlayer tablePlayer = new TablePlayer();
        public TablePlayerZones tablePlayerZones = new TablePlayerZones();

        [ServerCallback]
        protected override void Start()
        {
            base.Start();
        }

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
        }

        void OnDestroy()
        {
            
        }

        [Server]
        protected override void UpdateServer()
        {
            base.UpdateServer();
            this.InvokeInstanceDevExtMethods(nameof(UpdateServer));
        }

        [Client]
        protected override void UpdateClient()
        {
            base.UpdateClient();
            this.InvokeInstanceDevExtMethods(nameof(UpdateClient));
        }

        [Client]
        protected override void LateUpdateClient()
        {
            this.InvokeInstanceDevExtMethods(nameof(LateUpdateClient));
        }

        [Client]
        protected override void FixedUpdateClient()
        {

        }
    }
}
