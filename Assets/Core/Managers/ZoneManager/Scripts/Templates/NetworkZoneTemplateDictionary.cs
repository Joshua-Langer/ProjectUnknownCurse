﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using LangerNetwork.Debugging;

namespace LangerNetwork
{
    public partial class NetworkZoneTemplateDictionary
    {
        public readonly ReadOnlyDictionary<int, NetworkZoneTemplate> data;

        public NetworkZoneTemplateDictionary(string folderName="")
        {
            List<NetworkZoneTemplate> templates = Resources.LoadAll<NetworkZoneTemplates>(folderName).ToList();
            if (templates.HasDuplicates())
                DebugManager.LogWarning("[Warning] Skipped loading due to duplicate(s) in Resources subfolder: " + folderName);
            else
                data = new ReadOnlyDictionary<int, NetworkZoneTemplate>(templates.ToDictionary(x => x.hash, x => x));
        }
    }
}
