using UnityEngine;

namespace FlippyPong.Gameplay
{
    [RequireComponent(typeof(IField))]
    public class FieldFitToCamera : MonoBehaviour
    {
        [SerializeField] private Camera _camera = default;
        [SerializeField] private float _zOffset = default;

        private void Start()
        {
            var field = GetComponent<IField>();

            var toFit = field.Bounds.size;
            var screenRatio = (float) Screen.width / Screen.height;

            _camera.orthographicSize = GetFitRatio(screenRatio, toFit);

            Vector3 cameraPosition = field.Center;
            cameraPosition.z = _zOffset;

            _camera.transform.position = cameraPosition;
        }

        private float GetFitRatio(float screenRatio, Vector2 toFit)
        {
            var targetRatio = toFit.x / toFit.y;

            if (screenRatio >= targetRatio)
            {
                return toFit.y / 2;
            }

            var ratioDiff = targetRatio / screenRatio;
            return toFit.y / 2 * ratioDiff;
        }
    }
}
