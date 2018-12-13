using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour {

    Object[] randomRewards;
    public GameObject rewardPanel;
   // public GameObject rewards;
    public GameObject MapPanel;
    public GameObject battleHolder;
    public GameObject mainCamera;
    public GameObject worldPrefab;
    public GameObject confirmUiPanel;
    public GameObject winLoseText;
    public GameObject mainCanvas;
    public GameObject itemRewardImage;
    public GameObject overallcurrencyText1;
    public GameObject overallcurrencyText2;
    public GameObject overallcurrencyText3;
    public int currency1;
    public int currency2;
    public int currency3;


    public void Start()
    {
       randomRewards = Resources.LoadAll("Rewards", typeof(Sprite));
    }


    public void Map1p1()
    {
        confirmUiPanel.SetActive(true);
    }

    public void StartCombat()
    {
        MapPanel.SetActive(false);
        confirmUiPanel.SetActive(false);
        mainCamera.SetActive(false);
        worldPrefab.SetActive(false);
        battleHolder.SetActive(true);
        mainCanvas.SetActive(false);

    }
    public void NoButton()
    {
        confirmUiPanel.SetActive(false);
    }
    public void BackButton()
    {
        MapPanel.SetActive(false);
        confirmUiPanel.SetActive(false);
        rewardPanel.SetActive(false);
       
    }
    public void WinLoseBattle()
    {
        Sprite randomItem = (Sprite)randomRewards[Random.Range(0, randomRewards.Length)];
        itemRewardImage.GetComponent<Image>().sprite = randomItem; 
        mainCamera.SetActive(true);
        battleHolder.SetActive(false);
        MapPanel.SetActive(true);
        rewardPanel.SetActive(true);
        worldPrefab.SetActive(true);
        winLoseText.SetActive(false);
        mainCanvas.SetActive(true);

       
    }
    public void Currency1()
    {
        
        currency1 = Random.Range(0, 100);
        overallcurrencyText1.GetComponent<Text>().text = overallcurrencyText1.GetComponent<Text>().text += currency1.ToString();
        this.gameObject.GetComponent<Button>().interactable = false;
    }

    public void Currency2()
    {
        currency2 = Random.Range(0, 100);
        overallcurrencyText2.GetComponent<Text>().text = overallcurrencyText2.GetComponent<Text>().text += currency2.ToString();
        this.gameObject.GetComponent<Button>().interactable = false;
    }

    public void Currency3()
    {
        currency3 = Random.Range(0, 100);
        overallcurrencyText3.GetComponent<Text>().text = overallcurrencyText3.GetComponent<Text>().text += currency3.ToString();
        this.gameObject.GetComponent<Button>().interactable = false;
    }
}
