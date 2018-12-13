using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	public GameObject target;
	public Vector3 offset;
	public float smoothingAlpha = 0.05f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	
	
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPosition = target.transform.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetPosition, 0.05f);
	}
}