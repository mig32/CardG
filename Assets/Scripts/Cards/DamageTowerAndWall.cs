
public class DamageTowerAndWall : CardInterface
{
    private int m_towerDmg;
    private int m_wallDmg;
    private int m_cost;

    public DamageTowerAndWall(int towerDmg, int wallDmg, int cost)
    {
        m_towerDmg = towerDmg;
        m_wallDmg = wallDmg;
        m_cost = cost;
    }

    public override bool Apply(Player me, Player opponent)
    {
        if (me.TryUseMana(m_cost))
        {
            opponent.DamageTower(m_towerDmg);
            opponent.DamageWall(m_wallDmg);
            return true;
        }
        return false;
    }
}
