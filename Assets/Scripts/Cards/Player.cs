using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public CardsLibrary m_library;
    public Deck m_deck;
    public Hand m_hand;
    public Tower m_tower;
    public int m_handSize = 7;
    public Player m_thatGuy;

	// Use this for initialization
	void Start ()
    {
        m_deck.CrateDeck(m_library);

        for (int i = 0; i < m_handSize; i++)
        {
            int card = m_deck.PickCard();
            if (card >= 0)
            {
                m_hand.AddCard(card);
            }
        }
	}

    public bool DamageTower(int amount)
    {
        return m_tower.DamageTower(amount);
    }

    public void DamageWall(int amount)
    {
        m_tower.DamageWall(amount);
    }

    public bool Damage(int amount)
    {
        return m_tower.Damage(amount);
    }

	public void PlayCard(int idx)
    {
        int cardId = m_hand.PlayCard(idx);
        CardInterface card = m_library.GetCard(cardId);
        card.Apply(this, m_thatGuy);
    }
}
