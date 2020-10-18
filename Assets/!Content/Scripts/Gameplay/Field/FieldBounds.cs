using UnityEngine;

namespace FlippyPong.Gameplay
{
    [RequireComponent(typeof(IField))]
    public class FieldBounds : MonoBehaviour
    {
        private IField _field;

        [SerializeField] private GameObject _topBound = default;
        [SerializeField] private GameObject _bottomBound = default;

        private void Awake()
        {
            _field = GetComponent<IField>();

            var bottomLeft = _field.Bounds.min;
            var topLeft = bottomLeft + Vector3.up * _field.Bounds.size.y;
            var topRight = _field.Bounds.max;
            var bottomRight = topRight + Vector3.down * _field.Bounds.size.y;

            CreateBounds(new GameObject("Left"), bottomLeft, topLeft).transform.SetParent(transform);
            CreateBounds(new GameObject("Right"), bottomRight, topRight).transform.SetParent(transform);

            CreateBounds(_topBound, bottomLeft, bottomRight);
            CreateBounds(_bottomBound, topLeft, topRight);
        }

        private Collider2D CreateBounds(GameObject go, params Vector2[] points)
        {
            if (!go.TryGetComponent(out EdgeCollider2D bounds))
            {
                bounds = go.AddComponent<EdgeCollider2D>();
            }

            bounds.points = points;

            return bounds;
        }
    }
}
