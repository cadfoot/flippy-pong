using FlippyPong.Core;
using UnityEngine;

namespace FlippyPong.UI
{
    public class CustomizationMenuView : InjectableMonoBehaviour<ICustomizationMenuView>, ICustomizationMenuView
    {
        [SerializeField] private RectTransform _itemsRoot = default;

        public RectTransform ItemsRoot => _itemsRoot;
    }
}
