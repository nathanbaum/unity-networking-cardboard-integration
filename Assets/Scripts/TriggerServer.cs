using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace nb2255
{
    public class TriggerServer : ITrigger
    {
        public NetworkDiscovery nd = null;
        public NetworkManager nm = null;
        private callback closeMenu;

        void Start()
        {
            if( nd == null )
            {
                nd = FindObjectOfType<NetworkDiscovery>();
            }
            if (nm == null)
            {
                nm = FindObjectOfType<NetworkManager>();
            }
            nd.Initialize();
        }

        public override string GetName()
        {
            return "Start as Server";
        }

        public override void Toggle()
        {
            nm.StartHost();
            nd.StartAsServer();
            closeMenu();
        }

        public override void setCallBacks(callback close, setter set)
        {
            closeMenu = close;
        }

    }
}