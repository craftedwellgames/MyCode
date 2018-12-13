using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponInvent : MonoBehaviour
{

    public GameObject[] weaponInventory = new GameObject[12];
    public Image[] weaponInventoryImages = new Image[12];

    Sprite weaponChildsprite;
    public EquipmentInvent equipInv;


    public void FillWeaponInv(GameObject weaponinv)
    {
        bool weaponitemadded = false;


        for (int b = 0; b < weaponInventory.Length; b++)
            if (weaponInventory[b] == null)
            {
                if (weaponinv.GetComponent<Image>().sprite.name == "Weapon_Lv1")
                {
                    weaponInventory[b] = weaponinv;
                    //update ui
                    weaponChildsprite = weaponinv.GetComponent<Image>().sprite;
                    weaponInventoryImages[b].sprite = weaponChildsprite;
                    weaponInventoryImages[b].gameObject.SetActive(true);

                    weaponitemadded = true;
                }
                break;
            }
        //inventory full
        if (!weaponitemadded)
        {
            Debug.Log("Weapon inventory full");
        }
    }

}
