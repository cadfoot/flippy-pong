using UnityEngine;
using UnityEngine.Events;
using UnityInput = UnityEngine.Input;

namespace FlippyPong.Input
{
    public class AxisInput : MonoBehaviour, IInput
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
        [SerializeField] private float _speed = 1f;

        [SerializeField] private UnityEventFloat _onValueUpdated = default;

        private void Start()
        {
            Value = _default;
        }

        private void Update()
        {
            var input = UnityInput.GetAxisRaw("Horizontal");

            if (Mathf.Approximately(input, 0f))
            {
                return;
            }

            Value = Mathf.Clamp01(Value + input * _speed * Time.deltaTime);
        }
    }
}