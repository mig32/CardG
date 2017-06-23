using UnityEngine;
using System.Collections;
using System;

public class Table : MonoBehaviour {

    public Player m_activePlayer;
    public UnityEngine.UI.Text m_cardIdxText;
    // Use this for initialization
    void Start () {
        m_activePlayer.StartTurn();
    }

    public void NextTurn()
    {
        m_activePlayer = m_activePlayer.EndTurn();
        m_activePlayer.StartTurn();
    }

    public void PlayCard()
    {
        if (m_cardIdxText != null)
        {
            int idx = 0;
            if (m_cardIdxText.text.Length > 0)
            {
                idx = Int32.Parse(m_cardIdxText.text);
            }
            m_activePlayer.PlayCard(idx);
        }
    }
}
