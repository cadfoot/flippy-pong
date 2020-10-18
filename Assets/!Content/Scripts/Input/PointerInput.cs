using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityInput = UnityEngine.Input;

namespace FlippyPong.Input
{
    public class PointerInput : MonoBehaviour, IInput
    {
        public event UnityAction<float> OnValueUpdated
        {
            add => _onValueUpdated.AddListener(value);
            remove => _onValueUpdated.RemoveListener(value);
        }

        private float _value;

        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                _onValueUpdated?.Invoke(_value);
            }
        }

        [SerializeField] private float _default = .5f;

        [SerializeField] private UnityEventFloat _onValueUpdated = default;

        private void Start()
        {
            Value = _default;
        }

        private void Update()
        {
            if (!UnityInput.GetMouseButton(0) || EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Value = UnityInput.mousePosition.x / Screen.width;
        }
    }
}
