using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class timeManager : MonoBehaviour 
{
	public Text textfield;
	private float timer = 99999f;
	private float bestTime;
	private static GameObject currentTimeManager;

	// Use this for initialization
	void Start () 
	{
		//PlayerPrefs.DeleteAll ();
		if (currentTimeManager == null) 
		{
			currentTimeManager = this.gameObject;
			DontDestroyOnLoad (this.gameObject);
			bestTime = PlayerPrefs.GetFloat ("BestTime", 99999);
			timer = 0f;
		} 
		else 
		{
			Destroy (this.gameObject);

		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		textfield.text = "Current time: " + timer.ToString("0.00");
		textfield.text += "\nBest time: " + bestTime.ToString("0.00");
	}
		
	void OnDisable()
	{
		if (timer < bestTime) 
		{
			PlayerPrefs.SetFloat ("BestTime", timer);
		}
	}

}
