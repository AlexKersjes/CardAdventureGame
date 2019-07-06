using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellArgs
{
    public Character[] targets;

    public SpellArgs() { }
    public SpellArgs(Character[] targets)
    {
        this.targets = targets;
    }
}
