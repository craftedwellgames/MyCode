using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	public int maxAbPoints = 100;
	public int abPoints = 100;

	private float healthBarLength;
	private float abilityPointLength;

	// Use this for initialization
	void Start () 
	{
		healthBarLength = Screen.width;
	}
	
	// Update is called once per frame
	void Update () 
	{
		AddjustCurrentHealth (0);

	}
	void OnGUI ()
	{
		GUI.Box (new Rect (10, 10, healthBarLength, 20), curHealth + "/" + maxHealth);
		GUI.Box (new Rect (10, 40, abilityPointLength, 20), abPoints + "/" + maxAbPoints);
	}


	public void AddjustCurrentHealth (int adj)
	{
		curHealth += adj;

		if (curHealth < 0)
			curHealth = 0;

		
		

		if (curHealth > maxHealth)
			curHealth = maxHealth;

		if (maxHealth < 1)
			maxHealth = 1;

		healthBarLength = (Screen.width / 2) * (curHealth / (int)maxHealth);
		abilityPointLength = (Screen.width / 2) * (abPoints / (int)maxAbPoints);

	}
}
