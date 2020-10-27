using LangerNetwork;
using LangerNetwork.Database;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LangerNetwork.Network
{
    public partial class NetworkManager
    {
        [DevExtMethods(nameof(Awake))]
        void Awake_ScriptableTemplates()
        {
#if _SERVER && !_CLIENT
            PreloadScriptableTemplates();
#endif
        }

        protected void PreloadScriptableTemplates()
        {
            PreloaderComponent preloader = GetComponent<PreloaderComponent>();
            if (preloader)
                preloader.PreloadTemplates();
        }
    }
}