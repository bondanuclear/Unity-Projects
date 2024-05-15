using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacter : MonoBehaviour
{
    [SerializeField] AttackStrategy[] attackStrategy;
    AttackStrategy currentAttackStrategy;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            currentAttackStrategy = attackStrategy[0];
            
        } else if (Input.GetKeyDown(KeyCode.W))
        {
            currentAttackStrategy = attackStrategy[1];
            
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            currentAttackStrategy = attackStrategy[2];
            
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentAttackStrategy.Attack();
        }
    }

}
