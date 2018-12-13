using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bodyinvent : MonoBehaviour
{

    public GameObject[] bodyInventory = new GameObject[12];
    public Image[] bodyInventoryImages = new Image[12];

    Sprite bodyChildsprite;
    public EquipmentInvent equipInv;


    public void FillBodyInv(GameObject bodyinv)
    {
        bool bodyitemadded = false;


        for (int b = 0; b < bodyInventory.Length; b++)
            if (bodyInventory[b] == null)
            {
                if (bodyinv.GetComponent<Image>().sprite.name == "Chestplate_Lv1")
                {
                    bodyInventory[b] = bodyinv;
                    //update ui
                    bodyChildsprite = bodyinv.GetComponent<Image>().sprite;
                    bodyInventoryImages[b].sprite = bodyChildsprite;
                    bodyInventoryImages[b].gameObject.SetActive(true);

                    bodyitemadded = true;
                }
                break;
            }
        //inventory full
        if (!bodyitemadded)
        {
            Debug.Log("Body inventory full");
        }
    }

}