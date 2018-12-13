using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject itemBeingDragged;
  //  Vector3 startPosition;
    public enum Slot{HEAD, CHEST, WEAPON, BOOTS, LEGS, JEWLERY, INVENTORY};
    public Slot typeOfItem = Slot.INVENTORY;

    public int stackSize = 1;

    public void OnBeginDrag(PointerEventData eventData)
    {
       // GameObject duplicate = Instantiate(this.gameObject);
        itemBeingDragged = gameObject;
       // startPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.localPosition = Vector3.zero;
       // itemBeingDragged.transform.localPosition = Vector3.zero;
        itemBeingDragged = null;
       // transform.position = startPosition;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }



  
}
