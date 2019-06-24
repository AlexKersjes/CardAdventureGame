using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{ 

    Vector3 offset;
    Transform oldParent;
    GameObject placeholder;

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = eventData.position;
        oldParent = this.transform.parent;
        int i = this.transform.GetSiblingIndex();
        this.transform.SetParent(this.transform.parent.parent);


        placeholder = new GameObject();
        placeholder.transform.SetParent(oldParent);
        placeholder.transform.SetSiblingIndex(i);
        LayoutElement layout = placeholder.AddComponent<LayoutElement>();
        layout.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        layout.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        offset =  (Vector3)eventData.position - offset ;
        this.transform.position += offset;
        offset = eventData.position;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        int i = placeholder.transform.GetSiblingIndex();
        Destroy(placeholder);

        transform.SetParent(oldParent);
        transform.SetSiblingIndex(i);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }



}
