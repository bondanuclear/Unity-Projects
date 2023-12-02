using UnityEngine;
/// <summary>
/// Interface for the Map Generators
/// </summary>
public interface IMapGenerator {
    TerrainData GenerateTerrainData(int width, int length, int height, Vector2 seed, float scale);
}