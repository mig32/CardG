using System.Collections.Generic;
using UnityEngine;

public class CardsLibrary {

    Dictionary<int, CardInterfce> m_library;

    void Init()
    {
        m_library.Add(0, new DamageTowerAndWall(2, 4, 2));
        m_library.Add(0, new DamageTowerAndWall(5, 2, 4));
        m_library.Add(0, new DamageTowerAndWall(3, 3, 2));
        m_library.Add(0, new DamageTowerAndWall(2, 0, 1));
        m_library.Add(0, new DamageTowerAndWall(4, 0, 2));
        m_library.Add(0, new DamageTowerAndWall(0, 4, 2));
        m_library.Add(0, new DamageTowerAndWall(6, 0, 3));
        m_library.Add(0, new DamageTowerAndWall(2, 0, 1));
        m_library.Add(0, new DamageTowerAndWall(0, 8, 4));
    }

    public List<int> CreateDeck(int cardsAmount)
    {
        System.Random rnd = new System.Random();
        List<int> ret = new List<int>();
        for (int i = 0; i < cardsAmount; i++)
        {
            int idx = rnd.Next(0, m_library.Count);
            ret.Add(idx);
        }
        return ret;
    }

    public CardInterfce GetCard(int idx)
    {
        CardInterfce ret;
        if (m_library.TryGetValue(idx, out ret))
        {
            return ret;
        }
        Debug.logger.Log("Card with index %d not found in library", idx);
        return new ErrorCard();
    }
}
