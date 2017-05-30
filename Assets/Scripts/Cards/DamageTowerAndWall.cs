
public class DamageTowerAndWall : CardInterfce
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

    public override void Apply()
    {

    }
}
