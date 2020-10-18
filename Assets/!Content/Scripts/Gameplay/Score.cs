using Mirror;
using UnityEngine;

namespace FlippyPong.Network.Gameplay
{
    public class Score : NetworkBehaviour
    {
        [SyncVar(hook = nameof(OnScoreChanged))]
        private int _score;

        [SerializeField] private UnityEventInt _onScoreChanged = default;

        public override void OnStartServer()
        {
            _score = 0;
        }

        public override void OnStartClient()
        {
            _onScoreChanged?.Invoke(_score);
        }
        
        private void OnScoreChanged(int oldValue, int newValue)
        {
            _onScoreChanged?.Invoke(newValue);
        }

        [Server]
        public void Add(int amount)
        {
            _score += amount;
        }

        [Server]
        public void Set(int score)
        {
            _score = 0;
        }
    }
}
