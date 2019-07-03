using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Class",menuName = "CharacterClass")]
public class CharacterClass : Character
{
    public CharacterClass upgradesTo;
    public int level = 0;
    public string className;
    public List<Card> cards;
    public Equipment equip;
    [HideInInspector]
    public int hpModifier=0;

    public List<Card> GetCards()
    {
        return cards.Concat(equip.cards).ToList();
    }
    public int GetLevel()
    {
        return level;
    }
}
