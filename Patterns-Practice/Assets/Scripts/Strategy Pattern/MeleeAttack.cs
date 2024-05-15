using UnityEngine;


[CreateAssetMenu(fileName = "MeleeAttack", menuName = "AttackStrategy/MeleeAttackStrategy")]
class MeleeAttack : AttackStrategy
{
   
    public override void Attack()
    {
        Debug.Log("Attacking with melee weapon ");
    }


}
