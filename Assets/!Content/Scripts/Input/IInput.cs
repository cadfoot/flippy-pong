using UnityEngine.Events;

namespace FlippyPong.Input
{
    public interface IInput
    {
        event UnityAction<float> OnValueUpdated;

        float Value { get; }
    }
}
