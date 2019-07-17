using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothDamp : MonoBehaviour
{
    public Transform hand;
    GameObject placeholder;
    private Vector3 velocity = new Vector3(0,0,0);
    public HandScript.pseudoTransform target;
    private HandScript hs;
    private void Start()
    {
        this.transform.SetParent(this.transform.parent.parent);
        hs = hand.GetComponent<HandScript>();
        target = hs.AddTransform();
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(this.transform.position, target.position, ref velocity, 0.1f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 5f);
    }


}
