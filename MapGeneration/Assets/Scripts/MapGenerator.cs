using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Generates and manages the terrain and building placement in the scene.
/// </summary>
public class MapGenerator : MonoBehaviour
{
    /// <summary>
    /// Width of the terrain.
    /// </summary>
    [SerializeField] int terrainWidth = 256;
    /// <summary>
    /// Gets the width of the terrain.
    /// </summary>
    public int TerrainWidth => terrainWidth;
    /// <summary>
    /// Length of the terrain.
    /// </summary>
    [SerializeField] int terrainLength = 256;
    /// <summary>
    /// Gets the length of the terrain.
    /// </summary>
    public int TerrainLength => terrainLength;
    /// <summary>
    /// Height of the terrain.
    /// </summary>
    [SerializeField] int terrainHeight = 10;
    /// <summary>
    /// Gets the height of the terrain.
    /// </summary>
    public int TerrainHeight => terrainHeight;
    /// <summary>
    /// Scaling factor for the terrain.
    /// </summary>
    [SerializeField] float scale = 5;
    
    private Terrain terrain;
    /// <summary>
    /// Flag for randomizing the seed.
    /// </summary>
    [SerializeField] bool randomizeSeed = false;

    [Header("Building spawn parameters: ")]
    [SerializeField] int lengthWildCard = 10;
    [SerializeField] int widthWildCard = 10;
    /// <summary>
    /// Gets or sets the flag for randomizing the seed.
    /// </summary>
    public bool RandomizeSeed
    {
        get { return randomizeSeed; }
        set { randomizeSeed = value;}
    }
    [SerializeField] IMapGenerator mapGenerators;
    [SerializeField] List<BuildingBase> buildings;
    
    [SerializeField] int numBuildings = 20;
    /// <summary>
    /// Gets the seed for terrain generation.
    /// </summary>
    private Vector2 seed;
    public Vector2 Seed => seed;
    [SerializeField] Transform parent;
    private const float MinRandomRange = 0f;
    private const float MaxRandomRange = 9999f;
    /// <summary>
    /// Initializes the MapGenerator and terrain.
    /// </summary>
    public void Awake()
    {
        GenerateSeed();
        mapGenerators = GetComponent<IMapGenerator>();
        terrain = GetComponent<Terrain>();
        
    }
    /// <summary>
    /// Initializes the MapGenerator with specified map generator and terrain.
    /// </summary>
    /// <param name="_mapGenerator">The map generator to use.</param>
    /// <param name="terrain">The terrain to modify.</param>
    public void Initialize(IMapGenerator _mapGenerator, Terrain terrain)
    {   
        mapGenerators = _mapGenerator;
        this.terrain = terrain;
    }
    /// <summary>
    /// Generates a seed for terrain generation.
    /// </summary>
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

    /// <summary>
    /// Generates the terrain, destroys existing buildings, places new buildings, and applies texture.
    /// </summary>
    public void GenerateIMapGenerator()
    {
        DestroyBuildings();
        GenerateSeed();
        terrain.terrainData = mapGenerators.GenerateTerrainData(terrainWidth, terrainLength, terrainHeight, seed, scale);
        PlaceBuildings();
        ApplyTexture();
    }
    /// <summary>
    /// Destroys all existing buildings in the scene.
    /// </summary>
    private void DestroyBuildings()
    {
        BuildingBase[] buildings = FindObjectsOfType<BuildingBase>();
        if(buildings.Length <= 0) return;
        foreach(var building in buildings)
        {
            if(Application.isPlaying)
                Destroy(building.gameObject);
            else DestroyImmediate(building.gameObject);    
        }
    }
    /// <summary>
    /// Places buildings on the terrain.
    /// </summary>
    private void PlaceBuildings()
    {
        for (int i = 0; i < numBuildings; i++)
        {
            
            Vector3 position = new Vector3(Random.Range(lengthWildCard, terrainLength - lengthWildCard), 0, Random.Range(widthWildCard, terrainWidth - widthWildCard));
            float terrainHeight = terrain.SampleHeight(position);
           // Debug.Log(terrainHeight);
           
            position.y = terrainHeight;
        
            BuildingBase buildingPrefab = buildings[Random.Range(0, buildings.Count)];

            Vector3 boxSize = buildingPrefab.BoxSize;
           
            if (!Physics.CheckBox(position, boxSize))
            {
                float Ycoord = Random.Range(0, 359);
                GameObject buildingInstance = buildingPrefab.PlaceBuilding(position, Quaternion.Euler(0,Ycoord,0), parent);
                
                Vector3 normal = terrain.terrainData.GetInterpolatedNormal(position.x / terrain.terrainData.size.x, position.z / terrain.terrainData.size.z);
                buildingInstance.transform.rotation = Quaternion.FromToRotation(buildingInstance.transform.up, normal) * buildingInstance.transform.rotation;
                
            }
        }
    }
    /// <summary>
    /// Tests terrain generation and returns the generated TerrainData.
    /// </summary>
    /// <returns>The generated TerrainData.</returns>
    public TerrainData TestTerrainSpawn()
    {
        terrain.terrainData = mapGenerators.GenerateTerrainData(terrainWidth, terrainLength, terrainHeight, seed, scale);
        return terrain.terrainData;
        
    }
    [SerializeField] Texture2D texture;
    /// <summary>
    /// Applies a texture to the terrain.
    /// </summary>
    private void ApplyTexture()
    {
        TerrainLayer terrainLayer = new TerrainLayer();
        terrainLayer.diffuseTexture = texture;
        TerrainLayer[] terrainLayers = terrain.terrainData.terrainLayers;
        System.Array.Resize(ref terrainLayers, terrainLayers.Length + 1);
        terrainLayers[terrainLayers.Length - 1] = terrainLayer;
        terrain.terrainData.terrainLayers = terrainLayers;
    }
    
}

