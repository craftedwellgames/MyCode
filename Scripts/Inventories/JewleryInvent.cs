using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class JewleryInvent : MonoBehaviour
{

    public GameObject[] jewleryInventory = new GameObject[12];
    public Image[] jewleryInventoryImages = new Image[12];

    Sprite jewleryChildsprite;
    public EquipmentInvent equipInv;


    public void FillJewleryInv(GameObject jewleryinv)
    {
        bool jewleryitemadded = false;


        for (int b = 0; b < jewleryInventory.Length; b++)
            if (jewleryInventory[b] == null)
            {
                if (jewleryinv.GetComponent<Image>().sprite.name == "Pants_Lv1")
                {
                    jewleryInventory[b] = jewleryinv;
                    //update ui
                    jewleryChildsprite = jewleryinv.GetComponent<Image>().sprite;
                    jewleryInventoryImages[b].sprite = jewleryChildsprite;
                    jewleryInventoryImages[b].gameObject.SetActive(true);

                    jewleryitemadded = true;
                }
                break;
            }
        //inventory full
        if (!jewleryitemadded)
        {
            Debug.Log("Jewlery inventory full");
        }
    }

}