using System.Collections.Generic;

public class Hand {

    private List<int> m_hand;

    Hand()
    {
        m_hand = new List<int>();
    }

    public void AddCard(int card)
    {
        m_hand.Add(card);
    }

    public int PlayCard(int idx)
    {
        if (idx < m_hand.Count)
        {
            int card = m_hand[idx];
            m_hand.RemoveAt(idx);
            return card;
        }

        return -1;
    }
}
