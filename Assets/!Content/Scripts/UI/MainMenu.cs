using FlippyPong.Core;
using FlippyPong.Network;
using Injection;
using Mirror.Discovery;

namespace FlippyPong.UI
{
    public class MainMenu : InjectableMonoBehaviour<MainMenu>
    {
        [Inject] private NetworkManager _networkManager = default;
        [Inject] private IMainMenuView _view = default;
        
        private void Start()
        {
            if (_view == null)
            {
                return;
            }
            
            _view.OnHostButtonPressed += _networkManager.StartHost;
            _view.OnFindButtonPressed += _networkManager.StartDiscovery;
            _view.OnJoinButtonPressed += _networkManager.StartClient;
            
            _networkManager.OnServerFound.AddListener(OnServerFound);

            _view.JoinAvailable = false;
        }

        private void OnDestroy()
        {
            if (_view != null)
            {
                _view.OnHostButtonPressed -= _networkManager.StartHost;
                _view.OnFindButtonPressed -= _networkManager.StartDiscovery;
                _view.OnJoinButtonPressed -= _networkManager.StartClient;
            }
            
            _networkManager.OnServerFound.RemoveListener(OnServerFound);
            _networkManager.StopDiscovery();
        }
        
        private void OnServerFound(ServerResponse serverResponse)
        {
            _view.JoinAvailable = true;
        }
    }
}