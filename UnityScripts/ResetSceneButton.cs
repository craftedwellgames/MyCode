using UnityEngine;
using System.Collections;

public class ResetSceneButton : MonoBehaviour 
{
	public KeyCode reloadButton = KeyCode.R;

	private float initialFixedDeltaTime;
	
	// Use this for initialization
	void Start () 
	{
		initialFixedDeltaTime = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (reloadButton))
		{
			Time.fixedDeltaTime = initialFixedDeltaTime;
			Time.timeScale = 1f;
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
