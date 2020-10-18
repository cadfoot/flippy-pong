using System.Collections.Generic;
using FlippyPong.Customization;
using Injection;

namespace FlippyPong
{
    public interface IPersistentData : IInjectable
    {
        int HiScore { get; set; }
        int CustomizationIndex { get; set; }

        IReadOnlyList<ColorCustomization> Customization { get; }

        void Load();
        void Save();
    }
}
