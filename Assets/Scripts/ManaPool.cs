using System.Collections;

public class ManaPool {
    public int m_income = 10;
    public int m_pool = 0;
	
    public void Income()
    {
        m_pool += m_income;
    }

    public void AddMana(int amount)
    {
        m_pool += amount;
    }

    public void AddIncome(int amount)
    {
        m_income += amount;
    }

    public bool TryUseMana(int amount)
    {
        if (m_pool > amount)
        {
            m_pool -= amount;
            return true;
        }

        return false;
    }
}
