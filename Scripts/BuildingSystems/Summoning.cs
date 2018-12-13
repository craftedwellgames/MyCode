using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Summoning : MonoBehaviour {


    Object[] lowSummon;
    Object[] mediumSummon;
    Object[] highSummon;
    public GameObject fireParticle;
    public GameObject plasmaParticle;
    public GameObject shopButton;
    public Vector3 summonSpot;
    public GameController gc;
    public AudioSource buttonSound;
    public GameObject advancedSummonButton;

    int mediumParticle;
     void Start()
    {
        lowSummon = Resources.LoadAll("low",typeof(GameObject));
        mediumSummon = Resources.LoadAll("medium", typeof(GameObject));
        highSummon = Resources.LoadAll("high", typeof(GameObject));
        
    }

    void Update()
    {
        if (gc.advancedSummonScrolls > 0)
            advancedSummonButton.GetComponent<Button>().interactable = true;
    }

    public void LowSummon()
    {
        // play annimation code wait for seconds use ienumerator destroy annimation then do below for each
        //   buttonSound.Play();
       // shopButton.SetActive(false);
        gc.summonPanel.SetActive(false);
        gc.xButton.SetActive(false);
        Object lowSpawn = lowSummon[Random.Range(0, lowSummon.Length)];
        Instantiate(lowSpawn,summonSpot, Quaternion.Euler(0, 145, 0));


    }

    public void MediumSummon()
    {
        if (gc.advancedSummonScrolls > 0)
        {
            shopButton.SetActive(false);
            mediumParticle = Random.Range(0, 3);
            buttonSound.Play();
            //  fireParticle.SetActive(true);
            gc.summonPanel.SetActive(false);
            gc.xButton.SetActive(false);
            //  Object mediumSpawn = mediumSummon[Random.Range(0, mediumSummon.Length)];
            //  Instantiate(mediumSpawn, summonSpot, Quaternion.Euler(0,180,0));
            StartCoroutine(WaitTime());
            gc.advancedSummonScrolls -= 1;

        }
        else if (gc.advancedSummonScrolls == 0)
        {
            advancedSummonButton.GetComponent<Button>().interactable = false;
        }
    }

    public void HighSummon()

    {
        //shopButton.SetActive(false);
        // buttonSound.Play();
        gc.summonPanel.SetActive(false);
        gc.xButton.SetActive(false);
        Object highSpawn = highSummon[Random.Range(0, highSummon.Length)];
        Instantiate(highSpawn, summonSpot, Quaternion.Euler(0, 145, 0));
    }



    IEnumerator WaitTime()
    {
     //   Object mediumSpawn = mediumSummon[Random.Range(0, mediumSummon.Length)];
        if (mediumParticle <= 1)
        {
            fireParticle.SetActive(true);
        }
        if (mediumParticle > 1)
        {
            plasmaParticle.SetActive(true);
        }
      

        yield return new WaitForSeconds(2);
      
        SummonChar();
       // Instantiate(mediumSpawn, summonSpot, Quaternion.Euler(0, 180, 0));
    }

    public void SummonChar()
    {
        
        fireParticle.SetActive(false);
        plasmaParticle.SetActive(false);
        Object mediumSpawn = mediumSummon[Random.Range(0, mediumSummon.Length)];
        Instantiate(mediumSpawn, summonSpot, Quaternion.Euler(0, 180, 0));
       
    }
}

