using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using LangerNetwork;
using LangerNetwork.Network;
using LangerNetwork.Database;
using LangerNetwork.Debugging;
using LangerNetwork.UI;

namespace LangerNetwork.Zones
{
    [DisallowMultipleComponent]
    public class MultiWarpPortal : BasePortal
    {
        [Header("Teleportation")]
        [Tooltip("Anchor in the same scene to teleport to")]
        public string[] targetAnchors;

        public override void OnTriggerEnter(Collider co)
        {
			if (targetAnchors == null || targetAnchors.Length == 0)
			{
				DebugManager.LogWarning("You forgot to add anchors to MultiWarpPortal: " + this.name);
				return;
			}

			PlayerComponent pc = co.GetComponentInParent<PlayerComponent>();

			if (pc == null || !pc.IsLocalPlayer)
				return;

			if (!triggerOnEnter)
			{
				if (pc.CheckCooldown)
					UIPopupPrompt.singleton.Init(popupEnter, OnClickConfirm);
				else
					UIPopupNotify.singleton.Init(String.Format(popupWait, pc.GetCooldownTimeRemaining().ToString("F0")));
			}
			else
				OnClickConfirm();
		}

        public override void OnClickConfirm()
        {
			GameObject player = PlayerComponent.localPlayer;

			if (player == null)
				return;

			PlayerComponent pc = player.GetComponent<PlayerComponent>();

			int index = UnityEngine.Random.Range(0, targetAnchors.Length);
			string targetAnchor = targetAnchors[index];

			if (player != null && !String.IsNullOrWhiteSpace(targetAnchor) && pc.CheckCooldown)
				pc.Cmd_WarpLocal(targetAnchor);

			base.OnClickConfirm();
        }
    }
}