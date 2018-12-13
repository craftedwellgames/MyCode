using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableItem : MonoBehaviour {

    public bool inventory;  //if true this character can be added to inventory
    public bool equipmentInv; // if true this item will be added to inventory
  //  public Sprite placeholderSprite;

   public void DoInteraction()
    {
        if (inventory == true)
        {
            gameObject.SetActive(false);
        }

        // gameObject.GetComponent<Image>().sprite = placeholderSprite;
        //picked up and put up in inventory
        if (equipmentInv == true)
        {
            gameObject.SetActive(false);
            //  Destroy(gameObject);
            gameObject.GetComponent<Image>().raycastTarget = !enabled;
            // gameObject.GetComponent<Image>().sprite = null;
            // Destroy(this);


            // Destroy(gameObject);
        }
    }
}
