using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name+" was dropped");
        try
        {
            EncounterManager.Instance.CastSpell(GetSpellArgs(eventData));
        }
        catch (System.NullReferenceException e)
        {
            Debug.Log(e.Message);
            return;
        }

        //discard.cards.Insert(0,eventData.pointerDrag.GetComponent<CardDisplay>().card);
        Destroy(eventData.pointerDrag);
    }




    public SpellArgs GetSpellArgs(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<CardDisplay>().card;
        if (card.targetNo == 1)
        {
            CharacterInstance instance = this.GetComponent<CharacterInstance>();
            if (instance == null)
                throw new System.NullReferenceException("Card was not dropped on a character");
            if (card.TargetsAlly && instance.character is CharacterClass)
            {
                return new SingleArgs(card, instance);
            }
            else if (card.TargetsEnemy && instance.character is Enemy)
            {
                return new SingleArgs(card, instance);
            }

        }
        else if (card.targetNo == 0)
        {
            return new NoTargetArgs(card);
        }
        else
        {
            
        }
        throw new System.NotImplementedException("multitarget spells not implemented yet");
    }
}
