using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using LangerNetwork;
using LangerNetwork.Network;
using LangerNetwork.Database;
using LangerNetwork.Debugging;

namespace LangerNetwork.Zones
{
    [DisallowMultipleComponent]
    public partial class AnchorManager : MonoBehaviour
    {
        public List<PortalAnchorEntry> portalAnchors = new List<PortalAnchorEntry>();
        public List<StartAnchorEntry> startAnchors = new List<StartAnchorEntry>();

        public static AnchorManager singleton;

        void Awake()
        {
            portalAnchors.Clear();
            startAnchors.Clear();
            singleton = this;
        }

        public string GetArchetypeStartPositionAnchorName(GameObject player)
        {
            PlayerComponent pc = player.GetComponent<PlayerComponent>();
            startAnchors.Shuffle();
            foreach(StartAnchorEntry anchor in startAnchors)
            {
                foreach(ArchetypeTemplate template in anchor.archeTypes)
                {
                    if(template == pc.archeType)
                    {
                        DebugManager.LogFormat(nameof(AnchorManager), nameof(GetArchetypeStartPositionAnchorName), anchor.name);
                        return anchor.name;
                    }
                }
            }
            DebugManager.LogFormat(nameof(AnchorManager), nameof(GetArchetypeStartPositionAnchorName), "NOT FOUND");
            return "";
        }

        public bool CheckStartAnchor(string _name)
        {
            if (String.IsNullOrWhiteSpace(_name))
                return false;
            foreach(StartAnchorEntry anchor in startAnchors)
            {
                if(anchor.name == _name)
                {
                    DebugManager.LogFormat(nameof(AnchorManager), nameof(CheckStartAnchor), anchor.name);
                    return true;
                }
            }

            DebugManager.LogFormat(nameof(AnchorManager), nameof(CheckStartAnchor), _name, "NOT FOUND");
            return false;
        }

        public Vector3 GetStartAnchorPosition(string _name)
        {
            foreach(StartAnchorEntry anchor in startAnchors)
            {
                if(anchor.name == _name)
                {
                    DebugManager.LogFormat(nameof(AnchorManager), nameof(GetStartAnchorPosition), anchor.name);
                    return anchor.position;
                }
            }

            DebugManager.LogFormat(nameof(AnchorManager), nameof(GetStartAnchorPosition), _name, "NOT FOUND");
            return Vector3.zero;
        }

        public void RegisterStartAnchor(string _name, Vector3 _position, ArchetypeTemplate[] _archeTypes)
        {

            startAnchors.Add(
                            new StartAnchorEntry
                            {
                                name = _name,
                                position = _position,
                                archeTypes = _archeTypes
                            }
            );

            DebugManager.LogFormat(nameof(AnchorManager), nameof(RegisterStartAnchor), _name); //DEBUG
        }

        public void UnRegisterStartAnchor(string _name)
        {
            for (int i = startAnchors.Count - 1; i >= 0; i--)
            {
                if (startAnchors[i].name == _name)
                {
                    startAnchors.RemoveAt(i);
                    DebugManager.LogFormat(nameof(AnchorManager), nameof(UnRegisterStartAnchor), _name); //DEBUG
                }
            }
        }

        public bool CheckPortalAnchor(string _name)
        {

            if (String.IsNullOrWhiteSpace(_name))
                return false;

            foreach (PortalAnchorEntry anchor in portalAnchors)
            {
                if (anchor.name == _name)
                {
                    DebugManager.LogFormat(nameof(AnchorManager), nameof(CheckPortalAnchor), anchor.name); //DEBUG
                    return true;
                }
            }

            DebugManager.LogFormat(nameof(AnchorManager), nameof(CheckPortalAnchor), _name, "NOT FOUND"); //DEBUG
            return false;
        }

        public Vector3 GetPortalAnchorPosition(string _name)
        {

            foreach (PortalAnchorEntry anchor in portalAnchors)
            {
                if (anchor.name == _name)
                {
                    DebugManager.LogFormat(nameof(AnchorManager), nameof(GetPortalAnchorPosition), anchor.name); //DEBUG
                    return anchor.position;
                }
            }

            DebugManager.LogFormat(nameof(AnchorManager), nameof(GetPortalAnchorPosition), _name, "NOT FOUND"); //DEBUG
            return Vector3.zero;
        }

        public void RegisterPortalAnchor(string _name, Vector3 _position)
        {
            portalAnchors.Add(
                            new PortalAnchorEntry
                            {
                                name = _name,
                                position = _position
                            }
            );

            DebugManager.LogFormat(nameof(AnchorManager), nameof(RegisterPortalAnchor), _name); //DEBUG
        }

        public void UnRegisterPortalAnchor(string _name)
        {
            for (int i = portalAnchors.Count - 1; i >= 0; i--)
            {
                if (portalAnchors[i].name == _name)
                {
                    portalAnchors.RemoveAt(i);
                    DebugManager.LogFormat(nameof(AnchorManager), nameof(UnRegisterPortalAnchor), _name); //DEBUG
                }
            }
        }
    }
}
