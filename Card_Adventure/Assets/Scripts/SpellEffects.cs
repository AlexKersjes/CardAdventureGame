using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpellEffect
{
    public static void DamageSingle(SingleArgs e)
    {
        e.targets[0].TakeDamage(e.damageAmount);
    }


}
