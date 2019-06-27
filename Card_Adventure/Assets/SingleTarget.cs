using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SingleTarget : TargetingBehaviour
{
    public override Character[] GetTargets(List<GameObject> gameObjects)
    {
        return new Character[1] { gameObjects[0].GetComponent<Character>() };
    }
}
