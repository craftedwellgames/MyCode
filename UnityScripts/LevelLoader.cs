using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{


	private bool isPaused;

	public string currentLevelName;

	public GameObject pauseMenu;

	public GameObject GreyTexture;

	// Use this for initialization
	void Start ()
	{
		//makes the screen go a slighty lighter grey 
		GreyTexture.GetComponent<GUITexture> ().enabled = false;

		// checks if we are on the main screen if we are :
		if (SceneManager.GetActiveScene ().name == "Main") {

			//enable cursor and visibility 
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

		} else {

			// disable if were not :
			Cursor.lockState = CursorLockMode.Locked;
			isPaused = false;
			pauseMenu.GetComponent<Canvas> ().enabled = false;

		
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		//checks to see if we are presing esc 
		if (Input.GetKeyDown (KeyCode.Escape)) {

			// if we are normal mouse use
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			print ("exited the lockstate");

		}
			
		// Resets player to the start of the level

		if (Input.GetKeyDown (KeyCode.K)) {
			ResetLevel (currentLevelName);

		}

		//PAUSE
		if (Input.GetKeyDown (KeyCode.P)) {
			
			if (isPaused == false) {				
				PauseLevel ();
				print ("PAUSED");

			} else if (isPaused == true) {				
				UnPauseLevel ();
				print ("UNPAUSED");

			}
		}
	}

	//Loads level specified by a string entered in the editor

	public void LevelLoad (string levelName)
	{
		SceneManager.LoadScene (levelName);
	}

	// resets level specified in editor

	public void ResetLevel (string levelName)
	{		
		//Print("i have sent you back in time");
		SceneManager.LoadScene (levelName);

	}

	//Pauses the game
	public void PauseLevel ()
	{		
		//unlock mouse
		pauseMenu.GetComponent<Canvas> ().enabled = true;
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		isPaused = true;
		GreyTexture.GetComponent<GUITexture> ().enabled = true;
	}

	//Unpauses the game
	public void UnPauseLevel ()
	{
		
		//lock mouse
		pauseMenu.GetComponent<Canvas> ().enabled = false;
		Time.timeScale = 1f;
		isPaused = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		GreyTexture.GetComponent<GUITexture> ().enabled = false;
	}

	//quits the game
	public void QuitLevel ()
	{
		Application.Quit ();
	}
}
