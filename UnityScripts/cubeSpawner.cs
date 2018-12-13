using UnityEngine;
using System.Collections;

public class cubeSpawner : MonoBehaviour {
	public Texture2D map;
	public GameObject objToSpawn;
	public int x,y;
	public int gap;
	// Use this for initialization
	void Start () 
	{
		Color [] pixels = map.GetPixels ();
		foreach (Color pixel in pixels) {
			for (int x = 0;x<map.width; x++)
			{
				for (int y = 0;y<map.height; y++)
				{
			Vector3 spawnLocation = new Vector3 ();
			spawnLocation.x = x * gap;
			spawnLocation.y = y * gap;
					Debug.Log(pixel);

						Instantiate(objToSpawn,spawnLocation,Quaternion.identity);
			}
			}
		}

 	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
