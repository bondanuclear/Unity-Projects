using UnityEngine;

[CreateAssetMenu(fileName = "RangeAttack", menuName = "AttackStrategy/RangeAttackStrategy")]
class RangeAttack : AttackStrategy
{
    public GameObject projectilePrefab;
    public float speedOfProjectile;
    public override void Attack()
    {
        Debug.Log("Attack with range weapon ");
    }
}