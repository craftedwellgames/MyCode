using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeadInvent : MonoBehaviour {

    public GameObject[] headInventory = new GameObject[12];
    public Image[] headInventoryImages = new Image[12];
   
    Sprite headChildsprite;
    public EquipmentInvent equipInv;
    

    public void FillHeadInv(GameObject headinv)
    {
        bool headitemadded = false;

       
        for (int b = 0; b < headInventory.Length; b++)
            if (headInventory[b] == null)
            {
                if (headinv.GetComponent<Image>().sprite.name == "Helmet_Lv1")
                {
                    headInventory[b] = headinv;
                    //update ui
                    headChildsprite = headinv.GetComponent<Image>().sprite;
                    headInventoryImages[b].sprite = headChildsprite;
                    headInventoryImages[b].gameObject.SetActive(true);

                    headitemadded = true;
                }
               

                break;
            }
        //inventory full
        if (!headitemadded)
        {
             Debug.Log("Head inventory full");
            

        }
    }
   
}
















   