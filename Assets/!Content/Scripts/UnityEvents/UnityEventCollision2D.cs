using System;
using UnityEngine;
using UnityEngine.Events;

namespace FlippyPong
{
    [Serializable]
    public class UnityEventCollision2D : UnityEvent<Collision2D>
    {
    }
}
