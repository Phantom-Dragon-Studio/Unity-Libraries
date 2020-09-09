using System.Collections;

namespace PhantomDragonStudio.LevelManagement.Level_Management
{
    public class SceneLoader
    {
        public float Progress => loadingAsync.progress;
        
        private AsyncOperation loadingAsync;

        public IEnumerator Load(int sceneToLoad)
        {
            loadingAsync = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
            yield return loadingAsync;
            Scene nextActiveScene = SceneManager.GetSceneByBuildIndex(sceneToLoad);
            SceneManager.SetActiveScene(nextActiveScene);
        }
    }
}