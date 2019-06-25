using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Card card;
    public Image image;
    public Text cost;
    public Text description;
    public Text cardName;
	// Use this for initialization
	void Start () {
        if (card == null)
            throw new MissingReferenceException("No card reference");
        image.sprite = card.cardArt;
        cost.text = card.cost.ToString();
        description.text = card.cardText.ToString();
        cardName.text = card.cardName.ToString();
	}

}
