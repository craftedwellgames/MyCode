using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject currentInterObject = null;
 //   public GameObject currentEquipObject = null;
    public GameObject shopButton;
    public InteractableItem currentInterObjScript = null;
   // public InteractableItem currentInterEquipScript = null;
    public CharInventory inventory;
  //  public EquipmentInvent eqInventory;
    public GameController gc;
  //  public HeadInvent headInv;
   // public Bodyinvent bodyInv;
  //  public WaistInvent waistInv;
    //public WeaponInvent weaponInv;
    //public JewleryInvent jewlInv;
    //public BootInvent bootInv;

 


    void Update()
    {
        
            if (Input.GetMouseButtonDown(0))
              {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
               // Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag == "interObject")
                {
                    currentInterObject = hit.transform.gameObject;
                    currentInterObjScript = currentInterObject.GetComponent<InteractableItem>();
                    // check to see if this object is to be stored in inventory
                    if (currentInterObjScript.inventory)
                    {
                        inventory.AddItem(currentInterObject);
                        gc.summonPanel.SetActive(true);
                        gc.xButton.SetActive(true);
                        shopButton.SetActive(true);
                    }
                  
                }
            
               
            }
        }
    }
}
