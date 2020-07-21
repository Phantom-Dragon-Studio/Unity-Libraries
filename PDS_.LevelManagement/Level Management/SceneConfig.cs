﻿﻿using UnityEngine;

[CreateAssetMenu(fileName = "SceneConfig", menuName = "IntoToLevelDesign/SceneManagement")]
public class SceneConfig : ScriptableObject
{
    public string[] Layers;
        
    public static implicit operator string[] (SceneConfig config) => config.Layers;

    public string this[int index] => Layers[index];
    public int Count => Layers.Length;
}
