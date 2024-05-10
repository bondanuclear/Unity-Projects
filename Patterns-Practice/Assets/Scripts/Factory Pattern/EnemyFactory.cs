using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : ScriptableObject
{
    public abstract IEnemy CreateEnemy();
}
