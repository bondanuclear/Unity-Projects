using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] EnemyFactory enemyFactory;
    IEnemy enemy;   
    private void Start() {
       enemy = enemyFactory.CreateEnemy();
       enemy?.Attack();
    }
}