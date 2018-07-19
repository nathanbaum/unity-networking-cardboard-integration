using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace nb2255
{
    public class TriggerClient : ITrigger
    {
        public NetworkDiscovery nd = null;
        private callback closeMenu;

        void Start()
        {
            if (nd == null)
            {
                nd = FindObjectOfType<NetworkDiscovery>();
            }
            nd.Initialize();
        }

        public override string GetName()
        {
            return "Join existing as Client";
        }

        public override void Toggle()
        {
            nd.StartAsClient();
            closeMenu();
        }

        public override void setCallBacks(callback close, setter set)
        {
            closeMenu = close;
        }

    }
}