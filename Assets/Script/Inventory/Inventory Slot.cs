using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dorp = eventData.pointerDrag;
            DraggableItem draggableItem = dorp.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrage = transform;
        }
        else
        {
            GameObject dorp = eventData.pointerDrag;
            DraggableItem draggableItem = dorp.GetComponent<DraggableItem>();
            GameObject curretn = transform.GetChild(0).gameObject;
            DraggableItem curretnDraggable = curretn.GetComponent<DraggableItem>();
            curretnDraggable.transform.SetParent(draggableItem.parentAfterDrage);
            draggableItem.parentAfterDrage = transform;

        }
       

    }



}
