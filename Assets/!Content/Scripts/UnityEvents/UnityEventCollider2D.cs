using System;
using UnityEngine;
using UnityEngine.Events;

namespace FlippyPong
{
    [Serializable]
    public class UnityEventCollider2D : UnityEvent<Collider2D>
    {
    }
}
