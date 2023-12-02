using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Abstract class that is base for all spawnable objects
/// </summary>
public abstract class BuildingBase : MonoBehaviour, IBuildingPlacer
{
    public abstract Vector3 BoxSize {get;}

    public abstract GameObject PlaceBuilding(Vector3 position, Quaternion rotation, Transform parent);

}
