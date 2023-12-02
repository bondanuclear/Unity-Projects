using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePlacer : BuildingBase
{
    /// <summary>
    /// Sets the box size of the Building
    /// </summary>
    Vector3 boxSize = new Vector3(1,1,1);

    /// <summary>
    /// Property that overrides the BoxSize from BuildingBase
    /// </summary>
    public override Vector3 BoxSize { get => boxSize; }
    /// <summary>
    /// Overriden method that spawns the House
    /// </summary>
    /// <param name="position"> Position of spawned house</param>
    /// <param name="rotation">Rotation of spawned house</param>
    /// <param name="parent">Parent of the spawned house</param>
    /// <returns></returns>
    public override GameObject PlaceBuilding(Vector3 position, Quaternion rotation, Transform parent)
    {
        return Instantiate(gameObject, position, rotation, parent);
        
    }
    
}
