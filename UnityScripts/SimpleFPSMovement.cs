using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class SimpleFPSMovement : MonoBehaviour 
{
	public float speed = 5f;
	public float turnSpeed = 2000f;
	public Transform camTransform;

	private CharacterController cc;

	// Use this for initialization
	void Start () 
	{
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (0, (Input.GetAxis("Mouse X")/Screen.width) * turnSpeed, 0);
		camTransform.Rotate ( (Input.GetAxis("Mouse Y")/Screen.width) * -turnSpeed, 0, 0);

		Vector3 input = transform.forward * Input.GetAxisRaw ("Vertical") * speed;
		input += transform.right * Input.GetAxisRaw ("Horizontal") * speed;

		input = Vector3.ClampMagnitude (input, speed);

		cc.SimpleMove( input );

	}
}
