using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharInventory : MonoBehaviour {



    public GameObject[] inventory = new GameObject[9];
    public Image[] InventoryImages = new Image[9];
    public Image[] BattleInvImages = new Image[9];
    Sprite childsprite;

    public void AddItem(GameObject item)
    {
        bool itemadded = false;

        //find the first open slot in inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                //update ui
                childsprite = item.GetComponentInChildren<SpriteRenderer>().sprite;
                InventoryImages[i].sprite = childsprite;
                InventoryImages[i].gameObject.SetActive(true);
                BattleInvImages[i].sprite = InventoryImages[i].sprite;
                BattleInvImages[i].name = BattleInvImages[i].sprite.name;
              
              //  Debug.Log(item.name + "Was Added");
                itemadded = true;
                //do something with object
                item.SendMessage("DoInteraction");
                break;
            }
        }
        //inventory full
        if (!itemadded)
        {
            Debug.Log("inventory full");
        }

      
    }

}
