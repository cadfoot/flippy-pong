using Mirror;
using UnityEngine;

namespace FlippyPong.Gameplay.Server
{
    public class NetworkTeleportToFieldCenter : MonoBehaviour
    {
        [SerializeField] private Field _field = default;

        [Server]
        public void Teleport(NetworkTransform networkTransform)
        {
            networkTransform.ServerTeleport(_field.Center);
        }
    }
}