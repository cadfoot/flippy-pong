using FlippyPong.Customization;

namespace FlippyPong.Gameplay
{
    public interface IBall : ICustomizable<ColorCustomization>, ICustomizable<SizeCustomization>
    {

    }
}