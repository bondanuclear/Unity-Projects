using UnityEngine;

public interface IMapGenerator {
    TerrainData GenerateTerrainData(int width, int length, int height, Vector2 seed, float scale);
}