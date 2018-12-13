using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaistInvent : MonoBehaviour
{

    public GameObject[] waistInventory = new GameObject[12];
    public Image[] waistInventoryImages = new Image[12];

    Sprite waistChildsprite;
    public EquipmentInvent equipInv;


    public void FillWaistInv(GameObject waistinv)
    {
        bool waistitemadded = false;


        for (int b = 0; b < waistInventory.Length; b++)
            if (waistInventory[b] == null)
            {
                if (waistinv.GetComponent<Image>().sprite.name == "Belt_Lv1")
                {
                    waistInventory[b] = waistinv;
                    //update ui
                    waistChildsprite = waistinv.GetComponent<Image>().sprite;
                    waistInventoryImages[b].sprite = waistChildsprite;
                    waistInventoryImages[b].gameObject.SetActive(true);

                    waistitemadded = true;
                }
                break;
            }
        //inventory full
        if (!waistitemadded)
        {
            Debug.Log("Waist inventory full");
        }
    }

}