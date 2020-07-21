using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhantomDragonStudio.LevelManagement
{
    public class LoadingProgressProcessor : MonoBehaviour
    {
        private float progressAsPercentage;

        public IEnumerator GetSceneLoadProgress(List<AsyncOperation> aSyncOperations, float minimumLoadTime)
        {
            for (int i = 0; i < aSyncOperations.Count; i++)
            {
                while (!aSyncOperations[i].isDone)
                {
                    progressAsPercentage = 0;
                    foreach (AsyncOperation operation in aSyncOperations)
                    {
                        progressAsPercentage += operation.progress;
                    }
                    progressAsPercentage = Mathf.Clamp01(progressAsPercentage / aSyncOperations.Count / 0.9f * 100);
                    yield return null;
                }
            }
            aSyncOperations.Clear();
        }
    }
}