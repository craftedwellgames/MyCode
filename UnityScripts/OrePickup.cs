using UnityEngine;
using System.Collections;

public class OrePickup : MonoBehaviour {


	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter (Collider pickup)
	{
		if(pickup.gameObject.name == "cart" || pickup.gameObject.tag == "player")
			Destroy(gameObject);
	}
}
