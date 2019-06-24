using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{ 

    Vector3 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        offset = offset - (Vector3)eventData.position;
        this.transform.position -= offset;
        offset = eventData.position;
    }


    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

    }


}
