using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour, IBuildingPlacer
{
    public abstract Vector3 BoxSize {get;}

    public abstract GameObject PlaceBuilding(Vector3 position, Quaternion rotation, Transform parent);

}
