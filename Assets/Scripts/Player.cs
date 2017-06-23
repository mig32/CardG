using UnityEngine;

public class Player : MonoBehaviour {
    private CardsLibrary m_library;
    private Deck m_deck;
    private Hand m_hand;
    private Tower m_tower;
    private ManaPool m_manaPool;
    private bool m_isTurn = false;
    public int m_handSize = 7;
    public Player m_thatGuy;
    public string m_name = "Player";
    public UnityEngine.UI.Text m_gui;

	// Use this for initialization
	Player()
    {
        m_library = new CardsLibrary();
        m_deck = new Deck();
        m_hand = new Hand();
        m_tower = new Tower();
        m_manaPool = new ManaPool();

        m_deck.CrateDeck(m_library);

        for (int i = 0; i < m_handSize; i++)
        {
            Draw();
        }
	}

    void Start()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        if (m_gui != null)
        {
            m_gui.text = m_name + (m_tower.m_tower > 0 ? "" : " >>(LOOSER)<<") + (m_isTurn ? " <- TURN" : "");
            m_gui.text += "\n\nTower = " + m_tower.m_tower;
            m_gui.text += "\nWall = " + m_tower.m_wall;
            m_gui.text += "\n\nManaPool = " + m_manaPool.m_pool;
            m_gui.text += "\nIncome = " + m_manaPool.m_income;
            m_gui.text += "\n\n  >> Hand <<";
            int idx = 0;
            foreach (int cardId in m_hand.ShowCards())
            {
                m_gui.text += "\n     " + idx + " -> " + cardId;
                idx++;
            }
        }
    }

    public void Draw()
    {
        int card = m_deck.Draw();
        if (card >= 0)
        {
            m_hand.AddCard(card);
        }
    }

    void Upkeep()
    {
        m_manaPool.Income();
        Draw();
    }

    public Player EndTurn()
    {
        m_isTurn = false;
        return m_thatGuy;
    }

    public void StartTurn()
    {
        m_isTurn = true;
        Upkeep();
        UpdateStats();
        m_thatGuy.UpdateStats();
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

    public bool TryUseMana(int amount)
    {
        return m_manaPool.TryUseMana(amount);
    }

	public void PlayCard(int idx)
    {
        if (!m_isTurn)
        {
            return;
        }

        int cardId = m_hand.PlayCard(idx);
        if (cardId >= 0)
        {
            CardInterface card = m_library.GetCard(cardId);
            if (card.Apply(this, m_thatGuy))
            {
                m_hand.RemoveCard(idx);

                UpdateStats();
                m_thatGuy.UpdateStats();
            }
        }
    }
}
