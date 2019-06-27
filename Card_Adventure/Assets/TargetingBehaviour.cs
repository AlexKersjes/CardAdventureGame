using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new TargetingBehaviour", menuName = "TargetingBehaviour")]
public class TargetingBehaviour : ScriptableObject
{
    int numberOfTargets = 0;
    bool targetsCards = false;
    ScriptableObject targetType;


    public int GetTargetCount()
    {
        return numberOfTargets;
    }

    public virtual Character[] GetTargets ()
    {
        throw new System.NotImplementedException("Targeting behaviour not implemented");
    }

    public virtual Character[] GetTargets(CharacterClass @class)
    {
        throw new System.NotImplementedException("Targeting behaviour not implemented");
    }

    public virtual Character[] GetTargets(List<GameObject> gameObjects)
    {
        throw new System.NotImplementedException("Targeting behaviour not implemented");
    }
}
