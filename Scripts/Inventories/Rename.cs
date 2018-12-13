using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rename : MonoBehaviour {

	
	// Update is called once per frame
	void Update ()
    {
        this.gameObject.name = this.gameObject.GetComponentInChildren<Image>().sprite.name;
	}
}
