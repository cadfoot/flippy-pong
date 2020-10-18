using UnityEngine;

namespace FlippyPong.Gameplay
{
    public class PhysicsCollisionEvents2D : MonoBehaviour
    {
        [SerializeField] private UnityEventCollision2D _onEnter = default;
        [SerializeField] private UnityEventCollision2D _onStay = default;
        [SerializeField] private UnityEventCollision2D _onExit = default;

        private void OnCollisionEnter2D(Collision2D other)
        {
            _onEnter?.Invoke(other);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            _onStay?.Invoke(other);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _onExit?.Invoke(other);
        }
    }
}