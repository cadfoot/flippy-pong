using FlippyPong.Core;
using FlippyPong.Network;
using Injection;
using UnityEngine;
using UnityEngine.UI;

namespace FlippyPong.UI
{
    public class GameplayUI : InjectableMonoBehaviour<GameplayUI>
    {
        [Inject] private NetworkManager _networkManager = default;

        [SerializeField] private Button _exitButton = default;

        private void Start()
        {
            if (_networkManager)
            {
                _exitButton.onClick.AddListener(_networkManager.StopClient);
                _exitButton.onClick.AddListener(_networkManager.StopHost);                
            }
        }
        
        private void OnDestroy()
        {
            if (_networkManager)
            {
                _exitButton.onClick.RemoveListener(_networkManager.StopClient);
                _exitButton.onClick.RemoveListener(_networkManager.StopHost);                
            }
        }
    }
}
