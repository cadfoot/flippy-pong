using System;
using FlippyPong.Customization;

namespace FlippyPong.UI
{
    public interface ICustomizationItem
    {
        ICustomizationData Data { get; }

        bool Selected { set; }

        event Action<ICustomizationItem> OnClick;
    }
}
