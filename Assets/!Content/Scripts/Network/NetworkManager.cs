using Injection;
using Mirror;
using Mirror.Discovery;
using UnityEngine;

namespace FlippyPong.Network
{
    [RequireComponent(typeof(NetworkDiscovery))]
    public class NetworkManager : Mirror.NetworkManager, IInjectable
    {
        public delegate void NetworkConnectionDelegate(NetworkConnection connection);

        public event NetworkConnectionDelegate OnServerPlayerConnect;
        public event NetworkConnectionDelegate OnServerPlayerAdded;
        public event NetworkConnectionDelegate OnServerPlayerDisconnecting;

        private NetworkDiscovery _discovery;
        public ServerFoundUnityEvent OnServerFound => _discovery.OnServerFound;

        public override void Start()
        {
            base.Start();

            _discovery = GetComponent<NetworkDiscovery>();
            _discovery.OnServerFound.AddListener(response => networkAddress = response.uri.Host);
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            base.OnServerAddPlayer(conn);

            OnServerPlayerAdded?.Invoke(conn);
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
            
            OnServerPlayerConnect?.Invoke(conn);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            OnServerPlayerDisconnecting?.Invoke(conn);

            base.OnServerDisconnect(conn);
        }
        
        public void AdvertiseServer()
        {
            _discovery.AdvertiseServer();
        }

        public void StartDiscovery()
        {
            _discovery.StartDiscovery();
        }

        public void StopDiscovery()
        {
            _discovery.StopDiscovery();
        }
    }
}
