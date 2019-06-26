using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ally : Character
{
    int level=0;
    public string characterName;
    protected List<Card> cards;
    public Equipment equip;

    public List<Card> GetCards()
    {
        return cards.Concat(equip.cards).ToList();
    }
    public int GetLevel()
    {
        return level;
    }
}
