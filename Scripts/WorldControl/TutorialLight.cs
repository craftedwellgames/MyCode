using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialLight : MonoBehaviour {

    
    public Camera mainCamera;
    public Vector3 cameraMove;
    public GameObject openstorypanel;
    public GameObject nameselectpanel;
    public GameObject speciesselectpanel;


	// Use this for initialization
	void Start ()
    {
       
        openstorypanel.SetActive(true);
        nameselectpanel.SetActive(false);
        speciesselectpanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()

    {
		
	}
}
