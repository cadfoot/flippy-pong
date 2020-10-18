using UnityEngine;

namespace FlippyPong.Core
{
    static class Set60Fps
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Set()
        {
            UnityEngine.Application.targetFrameRate = 60;
        }
    }
}
