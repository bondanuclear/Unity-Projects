using UnityEngine;
/// <summary>
/// Interface for all spawnable objects
/// </summary>
public interface IBuildingPlacer {
    Vector3 BoxSize {get; }
    GameObject PlaceBuilding(Vector3 position, Quaternion rotation, Transform parent);
}