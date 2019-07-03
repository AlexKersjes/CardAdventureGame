using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
        cards.Remove(c);
        //cards.Remove(cards.Find(d => d.GetInstanceID().Equals(c.GetInstanceID())));
    }

    public void Draw ()
    {
        if (cards.Count > 0)
        {
            GameObject g = Instantiate(prefabCard, hand.transform);
            g.GetComponent<CardDisplay>().card = cards[0];
            g.transform.SetSiblingIndex(0);
            cards.RemoveAt(0);
        }
    }

    public void Shuffle()
    {
        for (int i =cards.Count-1; i>0; i--)
        {
            int index = Random.Range((int)0, (int)i+1);
            Card temp=cards[i];
            cards[i] = cards[index];
            cards[index] = temp;
        }
    }
}
