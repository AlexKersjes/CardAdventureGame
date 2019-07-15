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
        //storing starting values of card
        offset = eventData.position;
        oldParent = this.transform.parent;
        int i = this.transform.GetSiblingIndex();
        this.transform.SetParent(this.transform.parent.parent);

        //creating a placeholder for the card in hand
        placeholder = new GameObject();
        placeholder.name = "Layout Placeholder";
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

        int newSiblingIndex = placeholder.transform.parent.childCount ;
        if (this.transform.position.y < oldParent.transform.position.y)
        {
            for (int i = 0; i < oldParent.childCount; i++)
            {
                if (this.transform.position.x < oldParent.GetChild(i).position.x)
                {
                    newSiblingIndex = i;
                    if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                        newSiblingIndex--;
                    break;
                }

            }
        }
        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        int i = placeholder.transform.GetSiblingIndex();
        Destroy(placeholder);

        transform.SetParent(oldParent);
        transform.SetSiblingIndex(i);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnDestroy()
    {
        Destroy(placeholder);
    }


    public IEnumerator DrawAnimation(Transform deckTransform)
    {
        this.enabled=false;
        yield return new WaitForEndOfFrame();
        var pos = this.transform.position;
        transform.position = deckTransform.position;
        iTween.MoveTo(this.transform.gameObject, pos, 1);
        this.enabled = true;
        yield break;
    }
}
