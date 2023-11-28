using UnityEngine;

public interface IBuildingPlacer {
    Vector3 BoxSize {get; }
    GameObject PlaceBuilding(Vector3 position, Quaternion rotation);
}