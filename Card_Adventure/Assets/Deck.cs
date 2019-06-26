﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards;
    public GameObject hand;
    public GameObject prefabCard;
    public void AddCard (Card c)
    {
        cards.Insert(0, c); //index 0 is the top of the deck
    }
	
    public void AddBottom (Card c)
    {
        cards.Add(c);
    }

    public void Remove (Card c)
    {
        cards.Remove(cards.Find(d => d.cardId.Equals(c.cardId)));
    }

    public void Draw ()
    {
        if (cards.Count > 1)
        {
            GameObject g = Instantiate(prefabCard, hand.transform);
            g.GetComponent<CardDisplay>().card = cards[0];
            g.transform.SetSiblingIndex(0);
            cards.RemoveAt(0);
        }
    }
}