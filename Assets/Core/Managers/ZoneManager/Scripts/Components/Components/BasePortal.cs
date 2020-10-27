using System;
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
    public abstract partial class BasePortal : MonoBehaviour
    {
        [Header("Options")]
        [Tooltip("Trigger automatically on enter?")]
        public bool triggerOnEnter;

        [Header("System Texts")]
        public string popupEnter = "Enter {0}?";
        public string popupWait = "Please wait {0} seconds!";
        public string popupClose = "This portal is offline.";
        public string infoEntered = "You stepped into a warp portal.";

        public abstract void OnTriggerEnter(Collider co);
        public virtual void OnClickConfirm() { }
        public virtual void OnTriggerExit(Collider co)
        {
            PlayerComponent pc = co.GetComponentInParent<PlayerComponent>();
            if (pc == null || !pc.IsLocalPlayer)
                return;
            UIPopupPrompt.singleton.Hide();
        }
    }
}
