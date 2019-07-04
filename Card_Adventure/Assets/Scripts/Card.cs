using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


[CreateAssetMenu(fileName = "New Card",menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardText;
    private int cost = 0;

    public Sprite cardArt;
    public int targetNo=0;
    public bool targetsAlly=false;
    public bool targetsEnemy=false;
    public bool targetsCard=false;

    public int Cost
    {
        get
        {
            return cost;
        }

        set
        {
            cost = value;
        }
    }
}
