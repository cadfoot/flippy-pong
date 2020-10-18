using UnityEngine;

namespace FlippyPong.Gameplay
{
    public interface IField
    {
        Bounds Bounds { get; }
        Vector2 Center { get; }
    }
}
