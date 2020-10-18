using Injection;

namespace FlippyPong.Core
{
    public interface IInjectableMonoBehaviour : IInjectable
    {
        void InjectTo(Injector injector);
    }
}
