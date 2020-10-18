using FlippyPong.Network;
using Injection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlippyPong.Core
{
    public class Application : MonoBehaviour
    {
        private Injector _mainContext;

        [SerializeField] private NetworkManager _networkManager = default;
        
        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            _mainContext = new Injector();
            _mainContext.Bind<IPersistentData>(new PersistentData());
            _mainContext.Bind(_networkManager);
            _mainContext.PostBindings();
            
            DontDestroyOnLoad(gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
        {
            InitializeScene(scene, new Injector(_mainContext));
        }

        private static void InitializeScene(Scene scene, Injector context)
        {
            foreach (var go in scene.GetRootGameObjects())
            {
                foreach (var injectable in go.GetComponents<IInjectableMonoBehaviour>())
                {
                    injectable.InjectTo(context);
                }
            }
            
            context.PostBindings();
        }
    }
}
