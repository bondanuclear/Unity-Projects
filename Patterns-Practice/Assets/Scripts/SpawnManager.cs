using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] EnemyFactory enemyFactory;
    IEnemy enemy;   
    private void Start() {
    //    enemy = enemyFactory.CreateEnemy();
    //    enemy?.Attack();

        Enemy orc = new Enemy.Builder()
            .WithName("Orc with Axe")
            .WithArmor(10)
            .WithHealth(100)
            .WithSpeed(2.5f)
            .WithDamage(20)
            .Build();

        Debug.Log($"{orc.Name} is an enemy with {orc.Armor} armor, {orc.Damage} damage");
        //Instantiate(enemy);
    }
}