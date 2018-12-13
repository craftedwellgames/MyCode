using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgePanel : MonoBehaviour {

    public GameObject[] inventorySlots;
    public GameObject beforeSlot;
    public GameObject afterSlot;
    public GameObject addItemConfirm;
    private int stackCount;
    private Text beforeStackText;
    ItemDragHandler IDH;

    public void Update()
    {
       
        if (beforeSlot.gameObject.GetComponentInChildren<Image>().transform.Find("Helmet_Lv1"))
        {
            
            IDH = beforeSlot.gameObject.GetComponentInChildren<ItemDragHandler>();
            stackCount = IDH.stackSize;
            if (stackCount >= 4)
            {
                afterSlot.GetComponent<Image>().sprite = (Sprite)Resources.Load("HelmetEquipment/Helmet_Lv2", typeof(Sprite));
                afterSlot.GetComponentInChildren<Image>().gameObject.SetActive(true);
              
            }
           
        }

      
       
        //get stack count from before image and if its greater then 3 then put upgraded image into after slot
    }


    public void ForgeButton()
    {
        if (stackCount >= 4)
        addItemConfirm.SetActive(true);
     

    }
    public void ConfirmAddItem()
    {
        //IDH = beforeSlot.gameObject.GetComponentInChildren<ItemDragHandler>();
       // stackCount = IDH.stackSize;
        stackCount -= 3;
        beforeStackText = beforeSlot.gameObject.GetComponentInChildren<Text>();
        beforeStackText.text = stackCount.ToString();
        IDH.stackSize = stackCount;
        afterSlot.GetComponent<Image>().raycastTarget = enabled;
        addItemConfirm.SetActive(false);
       
    }
}
