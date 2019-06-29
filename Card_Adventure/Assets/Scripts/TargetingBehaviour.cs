using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new TargetingBehaviour", menuName = "TargetingBehaviour")]
public class TargetingBehaviour : ScriptableObject
{
    public int numberOfTargets = 0;
    public bool targetsCards = false;
    public ScriptableObject targetType = new Enemy();


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
