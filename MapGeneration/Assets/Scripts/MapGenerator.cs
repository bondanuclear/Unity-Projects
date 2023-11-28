using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] int terrainWidth = 256;
    public int TerrainWidth => terrainWidth;
    [SerializeField] int terrainLength = 256;
    public int TerrainLength => terrainLength;
    [SerializeField] int terrainHeight = 10;
    public int TerrainHeight => terrainHeight;
    [SerializeField] float scale = 5;
    
    private Terrain terrain;
    [SerializeField] bool randomizeSeed = false;
    public bool RandomizeSeed
    {
        get { return randomizeSeed; }
        set { randomizeSeed = value;}
    }
    [SerializeField] IMapGenerator mapGenerators;
    private Vector2 seed;
    public Vector2 Seed => seed;
    private const float MinRandomRange = 0f;
    private const float MaxRandomRange = 9999f;
    public void Awake()
    {
        GenerateSeed();
        mapGenerators = GetComponent<IMapGenerator>();
        terrain = GetComponent<Terrain>();
        
    }
    private void GenerateSeed()
    {
        if (randomizeSeed)
        {
            seed = new Vector2(Random.Range(MinRandomRange, MaxRandomRange), Random.Range(MinRandomRange, MaxRandomRange));
        }
        else
        {
            seed = Vector2.zero;
        }
    }
    

    public void GenerateIMapGenerator()
    {
        GenerateSeed();
        terrain.terrainData = mapGenerators.GenerateTerrainData(terrainWidth, terrainLength, terrainHeight, seed, scale);
    }
    public TerrainData TestTerrainSpawn()
    {
        GenerateIMapGenerator();
        return terrain.terrainData;
    }

    
}
