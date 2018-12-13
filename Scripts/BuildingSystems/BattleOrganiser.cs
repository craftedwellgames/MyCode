using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleOrganiser : MonoBehaviour
{

   public GameObject[] placementImages = new GameObject[9];
   public GameObject[] spawnPoint = new GameObject[9];
   public GameObject admiralPrefab;
    public GameObject angelPrefab;
    public GameObject hammerPrefab;
    public GameObject battleCanvas;
    public GameObject battleHolder;
    private int count = 1;

    public void BattleStart()
    {
        battleHolder.SetActive(true);
        battleCanvas.SetActive(false);
        foreach (GameObject pi in placementImages)
        {
         
            if (pi.gameObject.GetComponentInChildren<Image>().transform.Find("Admiral"))
            {
                var index = System.Array.IndexOf(placementImages, pi);
               GameObject newSpawn = Instantiate(admiralPrefab, spawnPoint[index].gameObject.transform);
                newSpawn.name = "Admiral" + count++;
                newSpawn.gameObject.GetComponent<HerroStateMachine>().hero.theName = newSpawn.name;
                //  Debug.Log("You spawned Admiral at " + spawnPoint[index].gameObject.transform);
                
            }

            if (pi.gameObject.GetComponentInChildren<Image>().transform.Find("angel face"))
            {
                var index = System.Array.IndexOf(placementImages, pi);
                GameObject newSpawn = Instantiate(angelPrefab, spawnPoint[index].gameObject.transform);
                newSpawn.name = "Proteger" + count++;
                newSpawn.gameObject.GetComponent<HerroStateMachine>().hero.theName = newSpawn.name;
                //  Debug.Log("You spawned Angel at " + spawnPoint[index].gameObject.transform);
               
            }

            if (pi.gameObject.GetComponentInChildren<Image>().transform.Find("The hammer"))
            {
                var index = System.Array.IndexOf(placementImages, pi);
                GameObject newSpawn = Instantiate(hammerPrefab, spawnPoint[index].gameObject.transform);
                newSpawn.name = "The Hammer" + count++;
                newSpawn.gameObject.GetComponent<HerroStateMachine>().hero.theName = newSpawn.name;
                // Debug.Log("You spawned Hammer at " + spawnPoint[index].gameObject.transform);
                
            }
        }
    }

}

    

