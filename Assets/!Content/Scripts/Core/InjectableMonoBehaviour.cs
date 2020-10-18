using System;
using Injection;
using UnityEngine;

namespace FlippyPong.Core
{
    public abstract class InjectableMonoBehaviour<T> : MonoBehaviour, IInjectableMonoBehaviour
        where T : IInjectable
    {
        void IInjectableMonoBehaviour.InjectTo(Injector injector)
        {
            if (this is T injectable)
            {
                injector.Bind(injectable);
            }
            else
            {
                throw new InvalidOperationException(
                    $"[INJECTOR] Injectable type {GetType()} must be or inherit from {typeof(T)}");
            }
        }
    }
}
