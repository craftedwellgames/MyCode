using UnityEngine;
using System.Collections;

public class LavaHazard : MonoBehaviour {

	public GameObject spawn;
	public Vector3 spawnPoint;
	public Transform player;


	void Start () {

		spawnPoint = spawn.transform.position;
	
	}
	

	void Update () {
	
	}

	void OnTriggerEnter(Collider burn){
		if (burn.gameObject.name == "cart"||burn.gameObject.tag == "player"){
			print ("Bang");
			player.transform.position = spawnPoint;
		}
	}
}
