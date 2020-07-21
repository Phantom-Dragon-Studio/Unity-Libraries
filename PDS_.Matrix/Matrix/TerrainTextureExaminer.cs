﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Optimize code
//Currently outputs 2.8MB of GC alloc and uses 16k+ draw calls. This is unacceptable.
namespace PhantomDragonStudio.Matrix
{
    public class TerrainTextureExaminer : MonoBehaviour
    {
        public int surfaceIndex = 0;

        private Terrain terrain;
        private TerrainData terrainData;
        private Vector3 terrainPos;

        private int mapX, mapZ, maxIndex;
        private float[] mix, cellMix;
        private float maxMix = 0;
        private float[,,] splatmapData;


        void Start()
        {
            cellMix = new float[500];
            terrain = Terrain.activeTerrain;
            terrainData = terrain.terrainData;
            terrainPos = terrain.transform.position;
            surfaceIndex = GetMainTexture(transform.position);
            if (surfaceIndex > 0)
            {
                GetComponent<MatrixTile>().SetToNOTVacant();
            }
        }

        private int GetMainTexture(Vector3 WorldPos)
        {
            // returns the zero-based index of the most dominant texture
            // on the main terrain at this world position.

            mix = GetTextureMix(WorldPos);
            maxMix = 0;
            maxIndex = 0;

            // loop through each mix value and find the maximum
            for (int n = 0; n < mix.Length; n++)
            {
                if (mix[n] > maxMix)
                {
                    maxIndex = n;
                    maxMix = mix[n];
                }
            }

            return maxIndex;
        }

        private float[] GetTextureMix(Vector3 WorldPos)
        {
            // returns an array containing the relative mix of textures
            // on the main terrain at this world position.

            // The number of values in the array will equal the number
            // of textures added to the terrain.

            // calculate which splat map cell the worldPos falls within (ignoring y)
            mapX = (int) (((WorldPos.x - terrainPos.x) / terrainData.size.x) * terrainData.alphamapWidth);
            mapZ = (int) (((WorldPos.z - terrainPos.z) / terrainData.size.z) * terrainData.alphamapHeight);

            // get the splat data for this cell as a 1x1xN 3d array (where N = number of textures)
            splatmapData = terrainData.GetAlphamaps(mapX, mapZ, 1, 1);

            // extract the 3D array data to a 1D array:
            cellMix = new float[splatmapData.GetUpperBound(2) + 1];

            for (int n = 0; n < cellMix.Length; n++)
            {
                cellMix[n] = splatmapData[0, 0, n];
            }

            return cellMix;
        }
    }
}