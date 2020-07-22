﻿﻿using System.Collections.Generic;
using PhantomDragonStudio.Input;
using PhantomDragonStudio.Matrix;
using UnityEngine;

public class RenderingToggle : MonoBehaviour
{
    private MatrixTile[] tiles;
    private readonly List<Renderer> renderers = new List<Renderer>();
    private bool gridRendering = false;
    private PlayerInputHandler Toggle;
    private void Awake()
    {
        tiles = FindObjectsOfType<MatrixTile>();
        foreach (var tile  in tiles)
        {
            renderers.Add((tile.GetComponent<Renderer>()));
        }
        
        DisableRendering();
    }

    private void Initialize()
    {
        Toggle = FindObjectOfType<PlayerInputHandler>();
        Toggle.Toggled += ToggleGrid;
    }
    
    public void ToggleGrid()
    {
        if(Toggle == null)
            Initialize();
        
        if (!gridRendering)
        {
            EnableRendering();
            gridRendering = true;
        }
        else
        {
            DisableRendering();
            gridRendering = false;
        }
    }

    private void EnableRendering()
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            renderers[i].enabled = true;
        }
    }

    private void DisableRendering()
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            renderers[i].enabled = false;
        }
    }
}
