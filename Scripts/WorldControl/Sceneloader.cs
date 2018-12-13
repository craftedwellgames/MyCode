using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Sceneloader : MonoBehaviour {

	
	void Start()
    {
        StartCoroutine("Wait");
	}
	

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(6);

        SceneManager.LoadScene(1);

        yield return new WaitForSeconds(10);

        SceneManager.LoadScene(2);
    }

}
