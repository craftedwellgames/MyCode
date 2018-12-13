using UnityEngine;
using System.Collections;

public class movement3 : MonoBehaviour {
	public float speed;
	
	private Rigidbody rb;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
	{
		float moveVertical = Input.GetAxis ("Horizontal");
		float moveHorizontal = -Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}
}