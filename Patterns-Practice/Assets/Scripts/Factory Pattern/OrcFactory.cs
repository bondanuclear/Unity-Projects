using UnityEngine;

[CreateAssetMenu(fileName = "OrcFactory", menuName = "EnemyFactory/Orc")]
public class OrcFactory : EnemyFactory
{
    public override IEnemy CreateEnemy()
    {
        return new Orc();
    }
}
