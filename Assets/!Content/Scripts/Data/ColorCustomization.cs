using UnityEngine;

namespace FlippyPong.Customization
{
    [CreateAssetMenu(menuName = "FlippyPong/" + nameof(ColorCustomization))]
    public class ColorCustomization : ScriptableObject, ICustomizationData
    {
        [SerializeField] private Color _color = Color.white;

        public Color Color => _color;
    }
}