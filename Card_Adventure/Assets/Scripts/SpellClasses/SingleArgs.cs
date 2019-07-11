using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleArgs : SpellArgs
{
    public SingleArgs (Card c, CharacterInstance target) : base(c)
    {
        targets = new CharacterInstance[1] { target };
    }

}
