using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace PhantomDragonStudio.LevelManagement
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