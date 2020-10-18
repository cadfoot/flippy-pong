using FlippyPong.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FlippyPong.UI
{
    public class MainMenuView : InjectableMonoBehaviour<IMainMenuView>, IMainMenuView
    {
        [SerializeField] private Button _hostButton = default;
        [SerializeField] private Button _findButton = default;
        [SerializeField] private Button _joinButton = default;
        
        public event UnityAction OnHostButtonPressed
        {
            add => _hostButton.onClick.AddListener(value);
            remove => _hostButton.onClick.RemoveListener(value);
        }
        
        public event UnityAction OnFindButtonPressed
        {
            add => _findButton.onClick.AddListener(value);
            remove => _findButton.onClick.RemoveListener(value);
        }
        
        public event UnityAction OnJoinButtonPressed
        {
            add => _joinButton.onClick.AddListener(value);
            remove => _joinButton.onClick.RemoveListener(value);
        }

        public bool JoinAvailable
        {
            set
            {
                _findButton.gameObject.SetActive(!value);
                _joinButton.gameObject.SetActive(value);
            }
        }
    }
}
