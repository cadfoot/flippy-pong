using FlippyPong.Core;
using FlippyPong.Customization;
using Injection;

namespace FlippyPong.Gameplay
{
    public class BallCustomizer : InjectableMonoBehaviour<BallCustomizer>
    {
        [Inject] private GameplayContext _gameplayContext = default;
        [Inject] private IPersistentData _data = default;

        private void Start()
        {
            if (_gameplayContext == null || _data == null)
            {
                return;
            }
            
            _gameplayContext.Ball.Apply(_data.Customization[_data.CustomizationIndex]);
            _gameplayContext.Ball.Apply(new SizeCustomization(UnityEngine.Random.Range(.5f, 2f)));
        }
    }
}
