using UnityEngine;
using System.Collections;

public class Scoreing : MonoBehaviour {

	public int Ore = 0;

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	public void OnGUI () 
	{
		GUI.Box(new Rect(10,50,150,30), "Gold Ore " + Ore);
	}

	public void OnTriggerEnter(Collider gold)
	{
		if(gold.gameObject.name == "Gold Ore" || gold.gameObject.tag == "Gold Ore")
		{
			Ore +=1;
		}
	}
}
