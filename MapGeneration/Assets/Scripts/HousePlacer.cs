using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePlacer : MonoBehaviour, IBuildingPlacer
{
    Vector3 boxSize = new Vector3(10,10,10);
    public Vector3 BoxSize { get => boxSize;}

    public void PlaceBuilding(Vector3 position, Quaternion rotation)
    {
        Instantiate(gameObject, position, rotation);
    }
}
