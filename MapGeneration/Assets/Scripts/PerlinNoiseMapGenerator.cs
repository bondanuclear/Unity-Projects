using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseMapGenerator : MonoBehaviour, IMapGenerator
{
    int width;
    int length;
    int height;
    Vector2 seed;
    float scale;
    
    public TerrainData GenerateTerrainData(int width, int length, int height, Vector2 seed, float scale)
    {
        TerrainData terrainData = new TerrainData();
        InitializeData(width, length, height, seed, scale);
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, height, length);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    private void InitializeData(int width, int length, int height, Vector2 seed, float scale)
    {
        this.width = width;
        this.length = length;
        this.height = height;
        this.seed = seed;
        this.scale = scale;
    }

    private float[,] GenerateHeights()
    {
        float[,] heights = new float[width, length];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    heights[x, y] = CalculateHeight(x, y);
                }
            }
            return heights;
    }
    float CalculateHeight(int x, int y)
    {
        float xCoord = seed.x + (float)x / width * scale;
        float yCoord = seed.y + (float)y / length * scale;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
