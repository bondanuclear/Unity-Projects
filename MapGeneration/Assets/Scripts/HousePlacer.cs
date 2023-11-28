using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePlacer : BuildingBase
{
    Vector3 boxSize = new Vector3(1,1,1);

    public override Vector3 BoxSize { get => boxSize; }
    public override GameObject PlaceBuilding(Vector3 position, Quaternion rotation)
    {
        return Instantiate(gameObject, position, rotation);
    }
    //public Vector3 BoxSize { get => boxSize;}

    // public void PlaceBuilding(Vector3 position, Quaternion rotation)
    // {
    //     Instantiate(gameObject, position, rotation);
    // }
}
