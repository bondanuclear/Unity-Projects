using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] EnemyFactory enemyFactory;
    IEnemy enemy;   
    private void Start() {
    //    enemy = enemyFactory.CreateEnemy();
    //    enemy?.Attack();

        Enemy enemy = new Enemy.Builder()
            .WithName("Orc with Axe")
            .WithArmor(10)
            .WithHealth(100)
            .WithSpeed(2.5f)
            .WithDamage(20)
            .Build();

        Debug.Log($"{enemy.Name} is an enemy with {enemy.Armor} armor, {enemy.Damage} damage");
        //Instantiate(enemy);
    }
}