using System;
using FlippyPong.Core;
using Injection;
using UnityEngine;

namespace FlippyPong.Gameplay
{
    public class HiScore : InjectableMonoBehaviour<HiScore>
    {
        [Inject] private IPersistentData _data = default;

        [SerializeField] private UnityEventInt _onHiScoreUpdated = default;

        private void Start()
        {
            _onHiScoreUpdated?.Invoke(_data.HiScore);
        }

        public void UpdateIfHigher(int score)
        {
            if (_data == null || _data.HiScore > score)
            {
                return;
            }

            _data.HiScore = score;
            _data.Save();
            
            _onHiScoreUpdated?.Invoke(score);
        }
    }
}
