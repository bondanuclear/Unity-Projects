public interface IEnemy
{
    void Attack();
    static IEnemy CreateDefault()
    {
        return new Orc();
    }
}