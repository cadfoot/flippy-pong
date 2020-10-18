using UnityEngine;

namespace FlippyPong.Gameplay
{
    public class PhysicsTriggerEvents2D : MonoBehaviour
    {
        [SerializeField] private UnityEventCollider2D _onEnter = default;
        [SerializeField] private UnityEventCollider2D _onStay = default;
        [SerializeField] private UnityEventCollider2D _onExit = default;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _onEnter?.Invoke(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            _onStay?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _onExit?.Invoke(other);
        }
    }
}