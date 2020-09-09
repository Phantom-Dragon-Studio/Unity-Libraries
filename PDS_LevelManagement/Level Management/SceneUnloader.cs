using System.Collections;

namespace PhantomDragonStudio.LevelManagement.Level_Management
{
    public class SceneUnloader
    {
        public float Progress => aSync.progress;
        
        private AsyncOperation aSync;
        public IEnumerator Unload(int sceneToUnload)
        {
            if (SceneManager.GetActiveScene().buildIndex == sceneToUnload && sceneToUnload != 0)
                aSync = SceneManager.UnloadSceneAsync(sceneToUnload);
            else
                Debug.Log("<color=YELLOW> Initial Persistent cannot be unloaded, only disabled. Skipping Unload Process. </color>");
            yield return aSync;
        }
    }
}