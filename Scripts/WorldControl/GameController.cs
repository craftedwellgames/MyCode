using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public GameObject world;
    public GameObject charPanel;
    public GameObject storePanel;
    public GameObject mapPanel;
    public GameObject mainCamera;
    public GameObject CharCamera;
    public GameObject summonCamera;
    public GameObject forgeCamera;
    public GameObject admiral;
    public GameObject hammer;
    public GameObject angel;
    public GameObject xButton;
    public GameObject equipInventory;
    public GameObject headInvPanel;
    public GameObject bodyInvPanel;
    public GameObject waistInvPanel;
    public GameObject weaponInvPanel;
    public GameObject jewleryInvPanel;
    public GameObject bootInvPanel;
    public GameObject summonPanel;
    public GameObject forgePanel;
    public GameObject confirmButton;
    public GameObject gameMenuPanel;
    public GameObject advancedSummonScrollsText;
    public int advancedSummonScrolls;
    public Text[] starCurrency;
    public GameObject vipPoints;
    public GameObject storePurchaseButton;
    public GameObject packageBundlePanel;
    public GameObject packPurchaseButton;
    public GameObject[] mainButtons;
    public Canvas canvasCamera;
    public UiHandler uihand;
    public AudioSource buttonSound;
    public AudioSource humanMainBkgrnd;
    public AudioSource changeUIPanels;
    public AudioSource forgeBkGrnd;
    public AudioSource moneySound;
    bool panelOpen = false;
    bool oneClick = false;
    float timerForDoubleClick;
    float delay = 0.3f;
    
   

   
    void Update()
    {
        advancedSummonScrollsText.GetComponent<Text>().text = advancedSummonScrolls.ToString();
        // settingsVid.Prepare();

        if (Input.GetMouseButtonDown(0))
        {
            if (!oneClick)
            {
                oneClick = true;
                timerForDoubleClick = Time.time;
               
               
            }

          else
            {
                oneClick = false;
               
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {

                    if (hit.transform.gameObject.tag == "ForgeBuilding")
                    {
                        changeUIPanels.Play();
                      //  charButton.SetActive(false);
                        humanMainBkgrnd.Stop();
                        mainCamera.SetActive(false);
                        forgePanel.SetActive(true);
                        forgeCamera.SetActive(true);
                        xButton.SetActive(true);

                       foreach (GameObject buttons in mainButtons)
                        {
                            buttons.SetActive(false);
                        }

                    }
                    else if (hit.transform.gameObject.tag == "AdventMapBuild")
                    {
                        changeUIPanels.Play();
                      //  charButton.SetActive(false);
                        mapPanel.SetActive(true);
                        // humanMainBkgrnd.Stop();
                    }
                    else if (hit.transform.gameObject.tag == "summonBuilding")
                    {
                        changeUIPanels.Play();
                      //  charButton.SetActive(false);
                        humanMainBkgrnd.Stop();
                        mainCamera.SetActive(false);
                        summonCamera.SetActive(true);
                        xButton.SetActive(true);
                        summonPanel.SetActive(true);
                        foreach (GameObject buttons in mainButtons)
                        {
                            buttons.SetActive(false);
                        }
                    }
                }

            }
          
        }
        if (oneClick)
        {
            if ((Time.time - timerForDoubleClick) > delay)
            {
                oneClick = false;
            }
        }
    }

    public void Xbutton()
    {

            world.SetActive(true);
            xButton.SetActive(false);
            humanMainBkgrnd.Play();
            forgeBkGrnd.Stop();
            buttonSound.Play();
            xButton.SetActive(false);
          //  dragoncharpanel.SetActive(false);
          //  brutecharpanel.SetActive(false);
            mainCamera.SetActive(true);
            CharCamera.SetActive(false);
            forgeCamera.SetActive(false);
            forgePanel.SetActive(false);
            charPanel.SetActive(false);
            admiral.SetActive(false);
            hammer.SetActive(false);
            angel.SetActive(false);
            summonPanel.SetActive(false);
            summonCamera.SetActive(false);
           // equiplayer.SetActive(false);
            uihand.bodyInventory.SetActive(false);
            uihand.headInventory.SetActive(false);
            uihand.waistInventory.SetActive(false);
            uihand.weaponInventory.SetActive(false);
            uihand.jewleryInventory.SetActive(false);
            uihand.bootsInventory.SetActive(false);
            confirmButton.SetActive(false);
            uihand.individPanel.SetActive(false);
            changeUIPanels.Play();
            mapPanel.SetActive(false);
            storePanel.SetActive(false);
            //  charButton.SetActive(true);
            foreach (GameObject buttons in mainButtons)
            {
                buttons.SetActive(true);
            }
        
    }

    public void EquipButton()
    {
        buttonSound.Play();
      //  equipInventory.SetActive(true);
      //  equiplayer.SetActive(true);
        charPanel.SetActive(false);
    }
    public void LvlButton()
    {
        buttonSound.Play();
        //  equipInventory.SetActive(false);
      //  equiplayer.SetActive(false);
        charPanel.SetActive(true);
        headInvPanel.SetActive(false);
        bodyInvPanel.SetActive(false);
        waistInvPanel.SetActive(false);
        weaponInvPanel.SetActive(false);
        jewleryInvPanel.SetActive(false);
        bootInvPanel.SetActive(false);
    }
    public void CharButton()
    {
        changeUIPanels.Play();
        humanMainBkgrnd.Stop();
        buttonSound.Play();
        xButton.SetActive(true);
        charPanel.SetActive(true);
        mainCamera.SetActive(false);
        CharCamera.SetActive(true);
       // charButton.SetActive(false);
        foreach (GameObject buttons in mainButtons)
        {
            buttons.SetActive(false);
        }
    }
    public void ShopButton()
    {
        world.SetActive(false);
        // humanMainBkgrnd.Stop();
        forgeBkGrnd.Stop();
      // Summonmusic.Stop();  
        buttonSound.Play();
        changeUIPanels.Play();
        storePanel.SetActive(true);
        forgePanel.SetActive(false);
        summonPanel.SetActive(false);
        charPanel.SetActive(false);
    }
    public void GameMenuPanel()
    {
        changeUIPanels.Play();
        if (panelOpen == false)
        {
           
            gameMenuPanel.SetActive(true);
            panelOpen = true;
        }
        else if (panelOpen == true)
        {
           
            gameMenuPanel.SetActive(false);
            panelOpen = false;
        }
    }
    public void PackButton()
    {
        storePurchaseButton.SetActive(false);
        packageBundlePanel.SetActive(true);
        packPurchaseButton.SetActive(true);
    }

    public void PurchasePackButton()
    {
        foreach (Text text in starCurrency)
        {
            text.text = "2000";
        }
        moneySound.Play();
        vipPoints.GetComponent<Text>().text = "Vip: 25";
        advancedSummonScrolls = 3;
        advancedSummonScrollsText.GetComponent<Text>().text = advancedSummonScrolls.ToString();
        storePurchaseButton.SetActive(true);
        packPurchaseButton.SetActive(false);
        packageBundlePanel.SetActive(false);
        
    }
}

