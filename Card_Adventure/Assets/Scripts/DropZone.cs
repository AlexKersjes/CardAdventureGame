using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Deck discard;


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name+" was dropped");
        discard.cards.Insert(0,eventData.pointerDrag.GetComponent<CardDisplay>().card);
        Destroy(eventData.pointerDrag);
    }
}
