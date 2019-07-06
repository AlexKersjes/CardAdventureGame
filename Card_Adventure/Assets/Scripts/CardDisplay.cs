using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CardDisplay : MonoBehaviour
{

    public Card card;
    public Image image;
    public Text cost;
    public Text description;
    public Text cardName;
	// Use this for initialization
	void Start () {
        if (card == null)
            throw new MissingReferenceException("No card reference");
        Refresh();
        try
        {
            this.gameObject.AddComponent(card.cardScript);
        }
        catch
        {
            throw new Exception("script for "+card.name+" could not be found or added.");
        }
	}

    void Refresh ()
    {
        image.sprite = card.cardArt;
        cost.text = card.Cost.ToString();
        description.text = card.cardText;
        cardName.text = card.name;
        this.name = card.name;
    }

}
