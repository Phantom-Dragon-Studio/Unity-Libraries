using System.Collections;

  namespace PhantomDragonStudio.LevelManagement.Level_Management
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Canvas splashCanvas = default; 
        [SerializeField] private float splashScreenDelay = default;
        [SerializeField] private int mainMenuIndex = default;
        [SerializeField] private bool autoLoad;
        
        
        public static LevelManager instance = null;
        private SceneLoader _sceneLoader;
        private SceneUnloader _sceneUnloader;
        private int lastSceneVisited;

        public void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            else
                instance = this;

            _sceneLoader = new SceneLoader();
            _sceneUnloader = new SceneUnloader();
            
            if(autoLoad)
                StartCoroutine(DelayedAutoLoad(mainMenuIndex, splashScreenDelay));
        }
        
        private IEnumerator DelayedAutoLoad(int nextLevelIndex, float timeDelay)
        {
            yield return new WaitForSeconds(timeDelay);
            LoadLevel(nextLevelIndex);
            splashCanvas.enabled = false;
        }
    
        public void LoadLevel(int requestedSceneIndex)
        {
            lastSceneVisited = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(_sceneLoader.Load(requestedSceneIndex));           
            StartCoroutine(_sceneUnloader.Unload(lastSceneVisited));
        }

        public void LoadPreviousScene()
        {
            LoadLevel(lastSceneVisited);
        }

        //TODO Add a way (C# event?) something can be triggered when a scene has finished loading, WITHOUT depending on it.
    }
}