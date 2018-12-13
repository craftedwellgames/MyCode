using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BootInvent : MonoBehaviour
{

    public GameObject[] bootInventory = new GameObject[12];
    public Image[] bootInventoryImages = new Image[12];

    Sprite bootChildsprite;
    public EquipmentInvent equipInv;


    public void FillBootInv(GameObject bootinv)
    {
        bool bootitemadded = false;


        for (int b = 0; b < bootInventory.Length; b++)
            if (bootInventory[b] == null)
            {
                if (bootinv.GetComponent<Image>().sprite.name == "Shoes_Lv1")
                {
                    bootInventory[b] = bootinv;
                    //update ui
                    bootChildsprite = bootinv.GetComponent<Image>().sprite;
                    bootInventoryImages[b].sprite = bootChildsprite;
                    bootInventoryImages[b].gameObject.SetActive(true);

                    bootitemadded = true;
                }
                break;
            }
        //inventory full
        if (!bootitemadded)
        {
            Debug.Log("Body inventory full");
        }
    }

}