using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card",menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardText;
    public int cost;

    public Sprite cardArt;
    public Object Script;
}
