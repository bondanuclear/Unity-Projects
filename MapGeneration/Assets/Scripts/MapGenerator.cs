using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] int terrainWidth = 256;
    [SerializeField] int terrainLength = 256;
    [SerializeField] int terrainHeight = 10;
    [SerializeField] float scale = 5;
    
    private Terrain terrain;
    [SerializeField] bool randomizeSeed = false;
    [SerializeField] IMapGenerator mapGenerators;
    private Vector2 seed;
    void Awake()
    {
        if(randomizeSeed)
        {
            seed = new Vector2(Random.Range(0f, 9999f), Random.Range(0f, 9999f));
        }
        // Get the Terrain component
        mapGenerators = GetComponent<IMapGenerator>();
        terrain = GetComponent<Terrain>();
        
    }

    // TerrainData GenerateTerrain(TerrainData terrainData)
    // {
    //     terrainData.heightmapResolution = terrainWidth + 1;
    //     terrainData.size = new Vector3(terrainWidth, terrainHeight, terrainLength);
    //     terrainData.SetHeights(0, 0, GenerateHeights());
    //     return terrainData;
    // }
    public void GenerateIMapGenerator()
    {
        if (randomizeSeed)
        {
            seed = new Vector2(Random.Range(0f, 9999f), Random.Range(0f, 9999f));

        } else
        {
            seed = Vector2.zero;
        }
        terrain.terrainData = mapGenerators.GenerateTerrainData(terrainWidth, terrainLength, terrainHeight, seed, scale);
    }
    // float[,] GenerateHeights()
    // {
    //     float[,] heights = new float[terrainWidth, terrainLength];
    //     for (int x = 0; x < terrainWidth; x++)
    //     {
    //         for (int y = 0; y < terrainLength; y++)
    //         {
    //             heights[x, y] = CalculateHeight(x, y);
    //         }
    //     }
    //     return heights;
    // }

    // float CalculateHeight(int x, int y)
    // {
    //     float xCoord = seed.x + (float)x / terrainWidth * scale;
    //     float yCoord = seed.y + (float)y / terrainLength * scale;

    //     return Mathf.PerlinNoise(xCoord, yCoord);
    // }
    // public void GenerateFromUI()
    // {
    //     if (randomizeSeed)
    //     {
    //         seed = new Vector2(Random.Range(0f, 9999f), Random.Range(0f, 9999f));
           
    //     } else
    //     {
    //         seed = Vector2.zero;
    //     }
    //     terrain.terrainData = GenerateTerrain(terrain.terrainData);
    // }
}
