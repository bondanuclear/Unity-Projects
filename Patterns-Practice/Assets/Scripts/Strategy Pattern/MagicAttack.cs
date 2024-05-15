using UnityEngine;


[CreateAssetMenu(fileName = "MagicAttack", menuName = "AttackStrategy/MagicAttackStrategy")]
class MagicAttack : AttackStrategy
{
    public GameObject magicProjectilePrefab;
    public float magicProjectileSpeed;
    public override void Attack()
    {
        Debug.Log("Attacking with magic ");
    }
}