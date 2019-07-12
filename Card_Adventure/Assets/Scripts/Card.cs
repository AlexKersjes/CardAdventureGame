using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


[CreateAssetMenu(fileName = "New Card",menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardText;
    [SerializeField]
    private int cost = 0;

    public Sprite cardArt;
    public int targetNo=0;
    [SerializeField]
    private bool targetsAlly = false;
    [SerializeField]
    private bool targetsEnemy = false;
    [SerializeField]
    private bool targetsCard = false;
    [SerializeField]
    private string CardScriptName;
    private Type cardScript;
    public Type CardScript { get { if(cardScript==null) cardScript = System.Reflection.Assembly.GetExecutingAssembly().GetType(CardScriptName); return cardScript; } }

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

    public bool TargetsCard
    {
        get
        {
            return targetsCard;
        }
    }

    public bool TargetsEnemy
    {
        get
        {
            return targetsEnemy;
        }
    }

    public bool TargetsAlly
    {
        get
        {
            return targetsAlly;
        }
    }
}
