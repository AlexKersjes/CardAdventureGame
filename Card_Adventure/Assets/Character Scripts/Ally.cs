using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ally : Character
{
    public int level=0;
    public string className;
    public List<Card> cards;
    public Equipment equip;
    public int hpIncrease;

    public List<Card> GetCards()
    {
        return cards.Concat(equip.cards).ToList();
    }
    public int GetLevel()
    {
        return level;
    }
}
