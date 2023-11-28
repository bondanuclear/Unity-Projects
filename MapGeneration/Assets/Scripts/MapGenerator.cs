using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    [SerializeField] List<BuildingBase> buildings;
    List<GameObject> instantiatedBuildings;
    [SerializeField] int numBuildings = 20;
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
        DestroyBuildings();
        GenerateSeed();
        terrain.terrainData = mapGenerators.GenerateTerrainData(terrainWidth, terrainLength, terrainHeight, seed, scale);
        PlaceBuildings();
        ApplyTexture();
    }
    private void DestroyBuildings()
    {
        HousePlacer[] buildings = FindObjectsOfType<HousePlacer>();
        if(buildings.Length <= 0) return;
        foreach(var building in buildings)
        {
            Destroy(building.gameObject);
        }
    }
    
    private void PlaceBuildings()
    {
        for (int i = 0; i < numBuildings; i++)
        {
            
            Vector3 position = new Vector3(Random.Range(0, terrainLength), 0, Random.Range(0, terrainWidth));
            float terrainHeight = terrain.SampleHeight(position);
            Debug.Log(terrainHeight);
           
            position.y = terrainHeight;
        
            BuildingBase buildingPrefab = buildings[Random.Range(0, buildings.Count)];

            Vector3 boxSize = buildingPrefab.BoxSize;
           
            if (!Physics.CheckBox(position, boxSize))
            {
                float Ycoord = Random.Range(0, 359);
                GameObject buildingInstance = buildingPrefab.PlaceBuilding(position, Quaternion.Euler(0,Ycoord,0));
                
                Vector3 normal = terrain.terrainData.GetInterpolatedNormal(position.x / terrain.terrainData.size.x, position.z / terrain.terrainData.size.z);
                buildingInstance.transform.rotation = Quaternion.FromToRotation(buildingInstance.transform.up, normal) * buildingInstance.transform.rotation;
                Debug.Log("Not overlapping");
            }else
            {
                Debug.Log("Already occupied!");
            }
        }
    }

    public TerrainData TestTerrainSpawn()
    {
        
        GenerateIMapGenerator();
        return terrain.terrainData;
        
    }
    [SerializeField] Texture2D texture;
    private void ApplyTexture()
    {
        TerrainLayer terrainLayer = new TerrainLayer();

        // Assign your texture to the TerrainLayer
        terrainLayer.diffuseTexture = texture;

        // Get the current array of TerrainLayers
        TerrainLayer[] terrainLayers = terrain.terrainData.terrainLayers;

        // Add your new TerrainLayer to the array
        System.Array.Resize(ref terrainLayers, terrainLayers.Length + 1);
        terrainLayers[terrainLayers.Length - 1] = terrainLayer;

        // Assign the updated array back to the TerrainData
        terrain.terrainData.terrainLayers = terrainLayers;
    }

}
