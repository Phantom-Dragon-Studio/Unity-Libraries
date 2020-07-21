﻿﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader_v2 : MonoBehaviour
{
public class SceneLoader
    {
        private MonoBehaviour _owner;
        public SceneLoader(MonoBehaviour owner) => _owner = owner;

        public void LoadScenes(params string[] sceneNames)
        {
            for (int i = 0; i < sceneNames.Length; i++) 
                LoadScene(sceneNames[i]);
        }

        void LoadScene(string name)
        {
            if (Exists(name))
                SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
            else UnableToFindScene(name);
        }

        private void UnableToFindScene(string name) => 
            Debug.LogFormat(LogType.Error,LogOption.NoStacktrace,null,"Scene Named <color=yellow>{0}</color> not found, failed to load",name);

        bool Exists(string name) => Application.CanStreamedLevelBeLoaded(name);
        public void Load(string level) => LoadScene(level);

        public void Load(string level, Action onComplete) => 
            _owner.StartCoroutine(Co_LoadScene(level, onComplete));

        IEnumerator Co_LoadScene(string sceneName,Action onComplete){
            async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            async.allowSceneActivation = true;
            while(async.progress < 0.9f) 
                OnLoadingProgressChanged(async.progress);
            
            while(!async.isDone)
                yield return null;

            OnReadyToLoadScene(async.progress);
            OnLoadingProgressChanged(1);
            async.allowSceneActivation = true;
            onComplete?.Invoke();
        }

        private void OnReadyToLoadScene(float progress)
        {
            
        }

        public Action<float> WhenBusy;
        
        private void OnLoadingProgressChanged(float progress) => WhenBusy?.Invoke(progress);

        private AsyncOperation async;
        
        public void Unload(string level)
        {
            if(!string.IsNullOrWhiteSpace(level))
                SceneManager.UnloadSceneAsync(level);
        }
    }
}
