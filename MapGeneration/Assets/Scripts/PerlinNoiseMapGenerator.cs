using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class that implements Perlin Noise Generator
/// </summary>
public class PerlinNoiseMapGenerator : MonoBehaviour, IMapGenerator
{
    /// <summary>
    /// Width of the map
    /// </summary>
    int width;
    /// <summary>
    /// Length of the map
    /// </summary>
    int length;
    /// <summary>
    /// Height of the map
    /// </summary>
    int height;
    /// <summary>
    /// Seed of the map
    /// </summary>
    Vector2 seed;
    /// <summary>
    /// Scale of the map
    /// </summary>
    float scale;
    /// <summary>
    /// Generates terrain data
    /// </summary>
    /// <param name="width">Width of the terrain</param>
    /// <param name="length">Length of the terrain</param>
    /// <param name="height">Height of the terrain</param>
    /// <param name="seed">Seed of the terrain</param>
    /// <param name="scale">Scale of the terrain</param>
    /// <returns>Terrain Data</returns>
    public TerrainData GenerateTerrainData(int width, int length, int height, Vector2 seed, float scale)
    {
        TerrainData terrainData = new TerrainData();
        InitializeData(width, length, height, seed, scale);
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, height, length);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }
    /// <summary>
    /// Initializing the data
    /// </summary>
    /// <param name="width">Width of the terrain</param>
    /// <param name="length">Length of the terrain</param>
    /// <param name="height">Height of the terrain</param>
    /// <param name="seed">Seed of the terrain</param>
    /// <param name="scale">Scale of the terrain</param>
    private void InitializeData(int width, int length, int height, Vector2 seed, float scale)
    {
        this.width = width;
        this.length = length;
        this.height = height;
        this.seed = seed;
        this.scale = scale;
    }
    /// <summary>
    /// Generating Heights for the terrain
    /// </summary>
    /// <returns>Two dimensional array of floats</returns>
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
    /// <summary>
    /// Calculates the height for the concrete point
    /// </summary>
    /// <param name="x">x coordinate of terrain</param>
    /// <param name="y">y coordinate of terrain</param>
    /// <returns>Value between 0 and 1 for given x and y</returns>
    float CalculateHeight(int x, int y)
    {
        float xCoord = seed.x + (float)x / width * scale;
        float yCoord = seed.y + (float)y / length * scale;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
   
}
