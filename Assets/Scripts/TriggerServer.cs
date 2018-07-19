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
        }

        public override string GetName()
        {
            return "Start as Server";
        }

        public override void Toggle()
        {
            nd.Initialize();
            nm.StartHost();
            nd.broadcastData = nm.networkPort.ToString();
            nd.StartAsServer();
            Debug.Log("Is running as server?: " + nd.isServer);
            Debug.Log("Broadcasting on port: " + nd.broadcastPort);
            closeMenu();
        }

        public override void setCallBacks(callback close, setter set)
        {
            closeMenu = close;
        }

    }
}