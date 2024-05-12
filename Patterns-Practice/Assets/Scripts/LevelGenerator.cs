using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] CaveFactory caveFactory;
    IEnemy casualMob =  IEnemy.CreateDefault();
    IEnemy levelBoss = IEnemy.CreateDefault();
    // we can create as many factories as we like in the abstract factory and then use it to create objects.
    private void Start() {
        if(caveFactory != null)
        {
            casualMob = caveFactory.CreateMob();
            levelBoss = caveFactory.CreateBoss();
        }

        Debug.Log($"Casual mob is {casualMob}");

        Debug.Log($"Boss is {levelBoss}");
    }
}