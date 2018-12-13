using UnityEngine;
using System.Collections;

public class BarrierCollide : MonoBehaviour 
{
	
	public int Lives;
	public int maxLives = 3;



	void Start () 
	{
		Lives = maxLives;
		//Barrier = GetComponent<GameObject> () Barrier;
	}

	void Update () 
	{
//		if (Player == Barrier) 
//		{
//			Health =- Damage;
//		}

		print (Lives);


		if (Lives <= 0) 
		{
			Destroy (gameObject);
		}
	}

	// not working needs to detect barrier either tag or collider and take health
	public void OnGUI ()
	{
		GUI.Box(new Rect(10,10,150,30), "Life Left " + Lives + "/" + maxLives);
	}

	void OnTriggerEnter (Collider barrier)
	{
		if(barrier.gameObject.name == "barrier" || barrier.gameObject.tag == "barrier")
		{
			Lives -= 1;
		}
		if(barrier.gameObject.name == "Lava" || barrier.gameObject.tag == "Lava")
		{
			Lives -= 1;
		}
	}		
}

