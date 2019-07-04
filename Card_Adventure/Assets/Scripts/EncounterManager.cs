using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : Singleton<EncounterManager>
{
    bool PlayerTurn = true;
    public Deck deck;
    public Deck discard;
    public Event SpellEffect;
    public GameEvent startPlayerTurn;
    public GameEvent startEnemyTurn;
    public GameEvent drawEvent;
    public GameEvent shuffleEvent;

    public void PassTurn()
    {
        PlayerTurn = !PlayerTurn;
        if (PlayerTurn)
        {
            startPlayerTurn.Raise();
        }
        else
        {
            startEnemyTurn.Raise();
        }
    }

    public void DrawCard()
    {
        if (deck.cards.Count == 0)
        {
            EmptyDraw();
        }
        drawEvent.Raise();
        //Debug.Log(deck.cards.Count.ToString() + "Cards left");
    }

    public void EmptyDraw()
    {
        deck.cards = discard.cards;
        discard.cards = new List<Card>();    
    }

    public void Shuffle()
    {
        shuffleEvent.Raise();
    }
}
