using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AttackStrategy : ScriptableObject {
    public GameObject weaponPrefab;
    public float damage;
    public float speedOfAttack;
    public float attackRadius;
    public abstract void Attack();  
}
