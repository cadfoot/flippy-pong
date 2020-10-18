using System;
using FlippyPong.Customization;
using UnityEngine;
using UnityEngine.UI;

namespace FlippyPong.UI
{
    [RequireComponent(typeof(Button))]
    public class CustomizationItem : MonoBehaviour, ICustomizationItem, ICustomizable<ColorCustomization>
    {
        private Button _button;

        [SerializeField] private Image _image = default;
        [SerializeField] private Image _selectedFrame = default;

        public ICustomizationData Data { get; private set; }

        public bool Selected
        {
            set => _selectedFrame.enabled = value;
        }

        public event Action<ICustomizationItem> OnClick;

        protected void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Clicked);
        }

        protected void OnDestroy()
        {
            _button.onClick.RemoveListener(Clicked);
        }

        public void Apply(ColorCustomization data)
        {
            Data = data;
            _image.color = data.Color;
        }

        private void Clicked()
        {
            OnClick?.Invoke(this);
        }
    }
}