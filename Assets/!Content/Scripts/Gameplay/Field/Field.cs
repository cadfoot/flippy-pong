using UnityEngine;

namespace FlippyPong.Gameplay
{
    public class Field : MonoBehaviour, IField
    {
        [SerializeField] private SpriteRenderer _boundsDefinition = default;

        public Bounds Bounds => _boundsDefinition.bounds;

        public Vector2 Center => _boundsDefinition.transform.position;
    }
}
