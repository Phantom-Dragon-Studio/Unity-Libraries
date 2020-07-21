﻿﻿using UnityEngine;

namespace PhantomDragonStudio.Matrix
{
    [SelectionBase]
    public partial class Matrix : MonoBehaviour
    {
        [SerializeField] MatrixTile tilePrefab = default;
        [SerializeField] [Range(0.1f, 100f)] public float matrixSpacing;
        [SerializeField] [Range(0.1f, 100f)] public float matrixHeight;
        [SerializeField] [Range(0.1f, 100f)] public float matrixSize;
        [SerializeField] public LayerMask _layerMask;


        public void DrawGrid()
        {
            for (float x = 0; x < matrixSize; x += matrixSpacing)
            { 
                for (float z = 0; z < matrixSize; z += matrixSpacing)
                {
                    for (float y = 0; y < matrixHeight; y += matrixSpacing)
                    {
                        var point = MatrixUtilities.SnapPlacement(new Vector3(x, y, z));
                        var newTile = Instantiate(tilePrefab, transform.position + point, Quaternion.identity, this.transform);
                        newTile.RemoveUnusableTiles(_layerMask);
                    }
                }
            }
        }
    }
}