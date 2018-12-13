using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using UnityEngine;

public class UiHandler : MonoBehaviour {

  //  public GameObject currentInterObject = null;
    public GameObject currentEquipObject = null;
    public GameObject shopButton;
 //   public InteractableItem currentInterObjScript = null;
    public InteractableItem currentInterEquipScript = null;
  //  public CharInventory inventory;
    public EquipmentInvent eqInventory;
    public GameController gc;
    public HeadInvent headInv;
    public Bodyinvent bodyInv;
    public WaistInvent waistInv;
    public WeaponInvent weaponInv;
    public JewleryInvent jewlInv;
    public BootInvent bootInv;
    public GameObject admiral;
    public GameObject hammer;
    public GameObject angel;
    public GameObject headInventory;
    public GameObject bodyInventory;
    public GameObject waistInventory;
    public GameObject weaponInventory;
    public GameObject jewleryInventory;
    public GameObject bootsInventory;
  //  public GameObject forgePanel;
    public GameObject charPanel;
    public GameObject hammerAnim;
    public GameObject angelAnim;
    public Image headImage;
    public GameObject confirmButton;
    public Image headslot1;
    public Image headslot2;
    public Image subHeadImage;
    public GameObject individPanel;
    public AudioSource buttonSound;
    public EquipmentInvent eqInventMain;
    public Image[] deleteInvImage;
    GraphicRaycaster gr;
    PointerEventData ped;
    EventSystem es;
    bool btn1 = false;
    bool btn2 = false;


    // Use this for initialization
    void Start()
    {
        gr = GetComponent<GraphicRaycaster>();
        es = GetComponent<EventSystem>();
       
    }

    // Update is called once per frame
    public void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            ped = new PointerEventData(es)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(ped, results);

            foreach (RaycastResult result in results)
            {

                if (result.gameObject.GetComponent<Image>().sprite.name == "Admiral")
                {
                    individPanel.SetActive(true);
                    admiral.SetActive(true);
                    hammer.SetActive(false);
                    angel.SetActive(false);
                }
                if (result.gameObject.GetComponent<Image>().sprite.name == "The hammer")
                {
                    individPanel.SetActive(true);
                    admiral.SetActive(false);
                    hammer.SetActive(true);
                    angel.SetActive(false);
                    hammerAnim.GetComponent<Animator>().SetTrigger("Idle");
                }
                if (result.gameObject.GetComponent<Image>().sprite.name == "angel face")
                {
                    individPanel.SetActive(true);
                    admiral.SetActive(false);
                    hammer.SetActive(false);
                    angel.SetActive(true);
                    angelAnim.GetComponent<Animator>().SetTrigger("Idle");
                }
                if (result.gameObject.GetComponent<Image>().name == "EquipmentTest")
                {

                    currentEquipObject = result.gameObject;
                    currentInterEquipScript = currentEquipObject.GetComponent<InteractableItem>();
                    // check to see if this object is to be stored in inventory
                    if (currentInterEquipScript.equipmentInv)
                    {
                        eqInventory.EquipAddItem(currentEquipObject);
                        headInv.FillHeadInv(currentEquipObject);
                        bodyInv.FillBodyInv(currentEquipObject);
                        waistInv.FillWaistInv(currentEquipObject);
                        weaponInv.FillWeaponInv(currentEquipObject);
                        jewlInv.FillJewleryInv(currentEquipObject);
                        bootInv.FillBootInv(currentEquipObject);
                    }
                }
                

                if (result.gameObject.name == "Head Button")
                    {

                        headInventory.SetActive(true);
                        bodyInventory.SetActive(false);
                        waistInventory.SetActive(false);
                        weaponInventory.SetActive(false);
                        jewleryInventory.SetActive(false);
                        bootsInventory.SetActive(false);
                    }
                    if (result.gameObject.name == "Chest Button")
                    {
                        headInventory.SetActive(false);
                        bodyInventory.SetActive(true);
                        waistInventory.SetActive(false);
                        weaponInventory.SetActive(false);
                        jewleryInventory.SetActive(false);
                        bootsInventory.SetActive(false);
                    }
                    if (result.gameObject.name == "Belt Button")
                    {
                        headInventory.SetActive(false);
                        bodyInventory.SetActive(false);
                        waistInventory.SetActive(true);
                        weaponInventory.SetActive(false);
                        jewleryInventory.SetActive(false);
                        bootsInventory.SetActive(false);
                    }
                    if (result.gameObject.name == "Weapon Button")
                    {
                        headInventory.SetActive(false);
                        bodyInventory.SetActive(false);
                        waistInventory.SetActive(false);
                        weaponInventory.SetActive(true);
                        jewleryInventory.SetActive(false);
                        bootsInventory.SetActive(false);
                    }
                    if (result.gameObject.name == "Feet Button")
                    {
                        headInventory.SetActive(false);
                        bodyInventory.SetActive(false);
                        waistInventory.SetActive(false);
                        weaponInventory.SetActive(false);
                        jewleryInventory.SetActive(true);
                        bootsInventory.SetActive(false);
                    }
                    if (result.gameObject.name == "Legs Button")
                    {
                        headInventory.SetActive(false);
                        bodyInventory.SetActive(false);
                        waistInventory.SetActive(false);
                        weaponInventory.SetActive(false);
                        jewleryInventory.SetActive(false);
                        bootsInventory.SetActive(true);
                    }

                

            }

        }
    }
    public void BtnSelect1()
    {

        btn1 = true;

    }
    public void BtnSelect2()
    {
        btn2 = true;
    }


    public void ConfirmPanelOpen()
    {
        if (charPanel.activeInHierarchy)
        {
            confirmButton.SetActive(true);
            subHeadImage.GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
        }
    }



    public void ConfirmButton()
    {
        headImage.sprite = subHeadImage.GetComponent<Image>().sprite;
        if (btn1 == true)
        {
            buttonSound.Play();
            headslot1.gameObject.SetActive(false);
            headslot1.GetComponent<Image>().sprite = null;
            btn1 = false;
            eqInventMain.equipInventory[0] = null;
            eqInventMain.equipInventoryImages[0] = null;
          //  deleteInvImage[0].gameObject.SetActive(false);
          //  deleteInvImage[0].GetComponent<Image>().sprite = null;
            deleteInvImage[0].GetComponent<Image>().sprite = deleteInvImage[1].GetComponent<Image>().sprite;
            deleteInvImage[1].gameObject.SetActive(false);
            deleteInvImage[1].GetComponent<Image>().sprite = null;
           
        }
        if (btn2 == true)
        {
            buttonSound.Play();
            headslot2.gameObject.SetActive(false);
            headslot2.GetComponent<Image>().sprite = null;
            btn2 = false;
        }


        subHeadImage.GetComponent<Image>().sprite = null;
        headInventory.SetActive(false);
        confirmButton.SetActive(false);
       
    }
   
}
