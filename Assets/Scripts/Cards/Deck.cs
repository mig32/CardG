using System.Collections.Generic;

public class Deck {

    public int m_deckSize = 60;
    private Stack<int> m_deck;

    // Use this for initialization
    public void CrateDeck(CardsLibrary library)
    {
        m_deck = library.CreateDeck(m_deckSize);
    }
	
	public int PickCard()
    {
        if (m_deck.Count > 0)
        {
            return m_deck.Pop();
        }

        return -1;
    }
}
