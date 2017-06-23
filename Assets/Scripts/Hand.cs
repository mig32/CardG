using System.Collections.Generic;

public class Hand {

    private List<int> m_hand;

    public Hand()
    {
        m_hand = new List<int>();
    }

    public void AddCard(int card)
    {
        m_hand.Add(card);
    }

    public void RemoveCard(int idx)
    {
        if (idx < m_hand.Count)
        {
            m_hand.RemoveAt(idx);
        }
    }

    public int PlayCard(int idx)
    {
        if (idx < m_hand.Count)
        {
            return m_hand[idx];
        }

        return -1;
    }

    public List<int> ShowCards()
    {
        return m_hand;
    }
}
