using Injection;
using UnityEngine;

namespace FlippyPong.UI
{
    public interface ICustomizationMenuView : IInjectable
    {
        RectTransform ItemsRoot { get; }
    }
}
