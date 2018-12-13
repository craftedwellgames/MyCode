using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	bool isPaused;

	public GameObject UICanvas;

	public GameObject UIPauseCanvas;

	private Scene scene;



	// Use this for initialization
	void Start () {	

		isPaused = false; 

		StartFunction ();

	}
	
	// Update is called once per frame
	void Update () {

		
	
		if (Input.GetKeyDown (KeyCode.Escape) && SceneManager.GetActiveScene().name == "Main Menu" ) {  // "
			print ("Escape Pressed");

			if (isPaused) {
				print ("isPaused");
				PauseFuncton ();
				isPaused = true;
			} else {

				print ("isResumed");
				ResumeFunction ();
				isPaused = false;
			}
		}


	}


	public void StartFunction(){

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		print ("game has started");
		UIPauseCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void LevelSelectingFunction(string sceneToLoad){


		SceneManager.LoadScene (sceneToLoad);

		//this will only load one level, need to find a way to get a choice of levels
	}

	public void PauseFuncton(){

		UIPauseCanvas.GetComponent<Canvas> ().enabled = true;
		Time.timeScale = 0;

	}

	public void ResumeFunction(){

		UIPauseCanvas.GetComponent<Canvas> ().enabled = false;
		Time.timeScale = 1;

	}

	public void QuitFunction(){

		Application.Quit();

	}
		
}
