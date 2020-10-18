using UnityEngine;

namespace FlippyPong.Gameplay
{
    public class RandomForce : MonoBehaviour
    {
        [SerializeField] private float _forceMin = default;
        [SerializeField] private float _forceMax = default;

        public void Apply(Rigidbody2D rb)
        {
            rb.velocity = Vector2.one * Random.Range(_forceMin, _forceMax);
        }
    }
}
