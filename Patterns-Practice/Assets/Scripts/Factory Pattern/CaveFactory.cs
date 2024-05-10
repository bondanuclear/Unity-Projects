using UnityEngine;


[CreateAssetMenu(fileName ="CaveFactory", menuName = "AbstractFactory/SimpleCaveFactory")]
public class CaveFactory : ScriptableObject
{
    public EnemyFactory casualEnemyFactory;
    public EnemyFactory bossEnemyFactory;

    public IEnemy CreateMob()
    {
        return casualEnemyFactory.CreateEnemy();
    }

    public IEnemy CreateBoss()
    {
        return bossEnemyFactory.CreateEnemy();
    }

    
}
