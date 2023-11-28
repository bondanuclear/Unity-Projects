using UnityEngine;

public interface IBuildingPlacer {
    Vector3 BoxSize {get; }
    void PlaceBuilding(Vector3 position, Quaternion rotation);
}