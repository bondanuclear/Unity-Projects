using UnityEngine;

[CreateAssetMenu(fileName = "DarkMageFactory", menuName = "EnemyFactory/DarkMage")]
public class DarkMageFactory : EnemyFactory
{
    public override IEnemy CreateEnemy()
    {
        return new DarkMage();
    }
}