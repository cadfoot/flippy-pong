using System.Collections;
using System.Linq;
using Mirror;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using NetworkManager = FlippyPong.Network.NetworkManager;

namespace FlippyPong.Gameplay.Network
{
    public class Server : NetworkBehaviour
    {
        [FormerlySerializedAs("paddles")] [SerializeField] private GameplayContext gameplayContext = default;
        
        [SerializeField] private UnityEvent _onSessionStart = default;
        [SerializeField] private UnityEvent _onRestart = default;
        
        private NetworkManager _networkManager;

        private void Awake()
        {
            _networkManager = (NetworkManager) Mirror.NetworkManager.singleton;

            if (_networkManager)
            {
                _networkManager.OnServerPlayerAdded += OnPlayerAdded;
                _networkManager.OnServerPlayerDisconnecting += OnPlayerDisconnecting;
                _networkManager.OnServerPlayerConnect += OnPlayerConnect;
            }
        }

        private void OnDestroy()
        {
            if (_networkManager)
            {
                _networkManager.OnServerPlayerAdded -= OnPlayerAdded;
                _networkManager.OnServerPlayerDisconnecting -= OnPlayerDisconnecting;
                _networkManager.OnServerPlayerConnect -= OnPlayerConnect;
            }
        }

        public void StartSession()
        {
            foreach (var paddle in gameplayContext.Paddles)
            {
                if (paddle.connectionToClient == null)
                {
                    paddle.AssignClientAuthority(NetworkServer.localConnection);
                }
            }
            
            _onSessionStart?.Invoke();
        }

        public void RestartSession()
        {
            _onRestart?.Invoke();
        }
        
        private void OnPlayerConnect(NetworkConnection connection)
        {
            var freePaddle = gameplayContext.Paddles.FirstOrDefault(paddle => paddle.connectionToClient == null);

            if (freePaddle == null)
            {
                connection.Disconnect();
            }
        }

        private void OnPlayerAdded(NetworkConnection connection)
        {
            var freePaddle = gameplayContext.Paddles.FirstOrDefault(paddle => paddle.connectionToClient == null);

            if (freePaddle != null)
            {
                freePaddle.AssignClientAuthority(connection);
                
                if (gameplayContext.Paddles.All(paddle => paddle.connectionToClient != null))
                {
                    _onSessionStart?.Invoke();
                }
            }
        }

        private void OnPlayerDisconnecting(NetworkConnection connection)
        {
            var playerPaddle = gameplayContext.Paddles.FirstOrDefault(paddle => paddle.connectionToClient == connection);

            if (playerPaddle != null)
            {
                playerPaddle.RemoveClientAuthority();
            }
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            
            _networkManager.AdvertiseServer();
        }
    }
}
