using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public ItemDragHandler.Slot typeOfItem = ItemDragHandler.Slot.INVENTORY;
   
    

    public GameObject Item{
        get {
            if (transform.childCount > 0)
            {
                Debug.Log("test1");
                return transform.GetChild(0).gameObject;
            }
            return null;
        }

    }
   

    public void OnDrop(PointerEventData eventData)
    {
        if (!Item)
        {
            Debug.Log("test2");
           // ItemDragHandler.itemBeingDragged.transform.SetParent(transform);

            ItemDragHandler d = eventData.pointerDrag.GetComponent<ItemDragHandler>();

            if (d != null)
            {
                if (typeOfItem == d.typeOfItem || typeOfItem == ItemDragHandler.Slot.INVENTORY)
                {
                    ItemDragHandler.itemBeingDragged.transform.SetParent(transform);
                }
            }
        }
    }
}
