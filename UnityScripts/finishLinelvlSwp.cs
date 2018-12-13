using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class finishLinelvlSwp : MonoBehaviour {

	public int level;

	void OnTriggerEnter (Collider col)

	{
		if (col.transform.tag == "player")
		{
			SceneManager.LoadScene (level);
		}
	}
}
// checks to see if player has collided with it if so load level