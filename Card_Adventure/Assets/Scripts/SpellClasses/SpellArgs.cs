using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellArgs
{
    public CharacterInstance[] targets;
    public Card card;
    public int damageAmount;
    public int blockAmount;

    public SpellArgs(Card c) { card = c; }
    public SpellArgs(Card c, CharacterInstance[] targets)
    {
        card = c;
        this.targets = targets;
    }
}
