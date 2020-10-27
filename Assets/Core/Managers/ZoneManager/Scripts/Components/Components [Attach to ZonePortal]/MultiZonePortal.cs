using System;
using System.Collections;
using System.Collections.Generic;
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
    public class MultiZonePortal : BasePortal
    {
        [Header("Teleportation")]
        [Tooltip("Target Network Zone to teleport to (optional)")]
        public NetworkZoneTemplate targetZone;
        [Tooltip("Anchor name in the target scene to teleport to")]
        public string[] targetAnchors;

        public string popupZoning = "Zoning, please wait...";

        public override void OnTriggerEnter(Collider co)
        {
            PlayerComponent pc = co.GetComponentInParent<PlayerComponent>();
            if (pc == null || !pc.IsLocalPlayer)
                return;
            if(!ZoneManager.singleton.GetCanSwitchZone)
            {
                UIPopupNotify.singleton.Init(popupClosed);
                return;
            }

            if (!triggerOnEnter)
            {
                if (pc.CheckCooldown)
                    UIPopupPrompt.singleton.Init(String.Format(popupEnter, targetZone.title), OnClickConfirm);
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

            if (player && targetZone != null && !String.IsNullOrWhiteSpace(targetAnchor) && pc.CheckCooldown)
                pc.WarpRemote(targetAnchor, targetZone.name);

            base.OnClickConfirm();

            if (UIPopupNotify.singleton)
                UIPopupNotify.singleton.Init(popupZoning, 10f, false);
        }
    }
}