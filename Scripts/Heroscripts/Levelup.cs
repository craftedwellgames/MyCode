using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Levelup : MonoBehaviour {

    int strength = 100;
    int defence = 50;
    int speed = 15;
    int level = 1;

    int dstrength = 100;
    int ddefence = 50;
    int dspeed = 15;
    int dlevel = 1;

    public Text strengthStat;
    public Text defenceStat;
    public Text speedStat;
    public Text levelStat;

    public Text dstrengthStat;
    public Text ddefenceStat;
    public Text dspeedStat;
    public Text dlevelStat;

  

    public GameObject levelbutton;
  
    // Use this for initialization
    void Start ()
    {
        
	}

    // Update is called once per frame
   /* void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "Brute")
                {
                   

                }

                if (hit.transform.gameObject.tag == "Dragon")
                {

                }
            }
        }

    }*/
    public void BruteLevelUp()
    {
        strength = strength + 10;
        defence = defence + 5;
        speed = speed + 2;
        level = level + 1;
        strengthStat.text = strength.ToString ();
        defenceStat.text = defence.ToString();
        speedStat.text = speed.ToString();
        levelStat.text = level.ToString() + "/30";
       // can use this to trigger level up animations
        if (level >= 30)
        {
            level = 30;
            levelStat.text = level.ToString() + " /30 EVOLVE";
            levelbutton.SetActive(false);
            
        }
    }
    public void DragonLevelUp()
    {
        dstrength = dstrength + 10;
        ddefence = ddefence + 5;
        dspeed = dspeed + 2;
        dlevel = dlevel + 1;
        dstrengthStat.text = dstrength.ToString();
        ddefenceStat.text = ddefence.ToString();
        dspeedStat.text = dspeed.ToString();
        dlevelStat.text = dlevel.ToString() + "/30";

        if (dlevel >= 30)
        {
            dlevel = 30;
            dlevelStat.text = dlevel.ToString() + " /30 EVOLVE";
            levelbutton.SetActive(false);
        }
    }
}
