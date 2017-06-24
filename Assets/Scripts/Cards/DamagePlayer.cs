
public class DamagePlayer : CardInterface
{
    private int m_playerDmg;
    private int m_cost;

    public DamagePlayer(int playerDmg, int cost)
    {
        m_playerDmg = playerDmg;
        m_cost = cost;
    }

    public override bool Apply(Player me, Player opponent)
    {
        if (me.TryUseMana(m_cost))
        {
            opponent.Damage(m_playerDmg);
            return true;
        }
        return false;
    }
}