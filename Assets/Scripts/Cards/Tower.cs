using System;
using System.Collections;

public class Tower {

    public int m_tower = 20;
    public int m_wall = 5;

    public bool DamageTower(int amount)
    {
        m_tower = Math.Max(0, m_tower - amount);
        return m_tower > 0;
    }

    public int DamageWall(int amount)
    {
        int towerDmg = amount - m_wall;
        if (towerDmg < 0)
        {
            m_wall = towerDmg;
            return 0;
        }

        m_wall = 0;
        return towerDmg;
    }

    public bool Damage(int amount)
    {
        return DamageTower(DamageWall(amount));
    }
}
