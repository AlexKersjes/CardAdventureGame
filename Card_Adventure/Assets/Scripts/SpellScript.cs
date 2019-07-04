using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    public delegate void SpellHandler();
    public SpellHandler spellHandler;
    public Event spell;
    private void Start()
    {
        
    }
    
}
