using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : ScriptableObject
{
    public CharacterClass upgradesTo;
    public Card[] baseCards;
    public Equipment baseEquipment;
    public int hpIncrease;
}
