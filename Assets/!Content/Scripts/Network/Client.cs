using Mirror;
using UnityEngine;
using UnityEngine.Events;

namespace FlippyPong.Gameplay.Network
{
    public class Client : NetworkBehaviour
    {
        [SerializeField] private UnityEvent _onSessionStart = default;
        [SerializeField] private UnityEvent _onSessionRestart = default;

        [ClientRpc]
        public void RpcStartSession()
        {
            _onSessionStart?.Invoke();
        }

        [ClientRpc] 
        public void RpcRestartSession()
        {
            _onSessionRestart?.Invoke();
        }
    }
}
