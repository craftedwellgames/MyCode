using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class EquipmentInvent : MonoBehaviour
{

    public GameObject[] equipInventory = new GameObject[20];
    public Image[] equipInventoryImages = new Image[20];
    Sprite equipChildsprite;
  
    int maxStackSize = 10;
   
     ItemDragHandler iDH;

   

    public void EquipAddItem(GameObject equipitem)
    {
       
        bool equipitemadded = false;

        //find the first open slot in inventory
        for (int i = 0; i < equipInventory.Length; i++)
        {
           
           // if (equipInventory[i].gameObject.GetComponent<Sprite>().name == equipInventory[i].gameObject.GetComponent<Sprite>().name && stackCount < maxStackSize)
           if (equipInventory[i] != null)
            {
                if (equipitem.GetComponent<Image>().sprite.name == equipInventoryImages[i].name)
                {
                    equipInventory[i] = equipitem;
                    equipInventoryImages[i].sprite = equipitem.GetComponent<Image>().sprite;
                   
                    iDH = equipInventoryImages[i].GetComponent<ItemDragHandler>();
                    if (equipitem.GetComponent<Image>().sprite.name == equipitem.GetComponent<Image>().sprite.name && iDH.stackSize < maxStackSize)
                    {
                        // Debug.Log(equipitem.GetComponent<Image>().sprite.name);
                        iDH.stackSize++;
                        equipInventoryImages[i].GetComponentInChildren<Text>().text = iDH.stackSize.ToString();
                        equipitem.SendMessage("DoInteraction");
                        //  Destroy(equipitem);


                        return;
                    }
                   
                   
                }
               
            }
           
            else if (equipInventory[i] == null)
            {
                Debug.Log("New Item New Spot");
                equipInventory[i] = equipitem;
                //update ui
               // equipChildsprite = equipitem.GetComponent<Image>().sprite;
                equipInventoryImages[i].sprite = equipitem.GetComponent<Image>().sprite;
                equipInventoryImages[i].gameObject.SetActive(true);


                // Debug.Log(equipitem.name + "Was Added");
                equipitemadded = true;
                //do something with object
                equipitem.SendMessage("DoInteraction");
              

                return;
            }
           
        }
        //inventory full
        if (!equipitemadded)
        {
            Debug.Log("inventory full");
        }

    }
}
