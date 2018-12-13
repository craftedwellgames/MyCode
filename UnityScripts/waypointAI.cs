using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class waypointAI : MonoBehaviour 
{
	public float patrolSpeed, chaseSpeed;
	public enum AiState { PATROL, CHASE };
	public List<Transform> waypoints;
	public float waypointRange = 1f;
	public float sightRadius = 5f;
	public float sightDot = 0f;
	public Transform chaseTarget;
	public LayerMask sightBlockingLayers;

	private int target = 0;
	private AiState currentState = AiState.PATROL;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	switch (currentState) {
		case AiState.PATROL:
			//do patrol stuff
			PatrolUpdate ();
			break;
		case AiState.CHASE:
			//do chase stuff
			ChaseUpdate ();
			break;
		default:
			// do default stuff
			break;
		}
	}
	void PatrolUpdate () 
	{
		transform.LookAt (waypoints[target].position);

		transform.Translate (transform.forward * patrolSpeed * Time.deltaTime, Space.World);
		if ((waypoints[target].position - this.transform.position).magnitude < waypointRange) 
		{
			target = ++target % waypoints.Count;
		}
		Vector3 vectorToTarget = chaseTarget.position - this.transform.position;
		if (vectorToTarget.magnitude < sightRadius) {
			if (Vector3.Dot (transform.forward, vectorToTarget.normalized) > sightDot) {
				if (!Physics.Linecast (transform.position, chaseTarget.position, sightBlockingLayers)) {
					currentState = AiState.CHASE;
				}
			}
		}

	}
	void ChaseUpdate () 
	{
		transform.LookAt (chaseTarget.position);
		
		transform.Translate (transform.forward * chaseSpeed * Time.deltaTime, Space.World);

		if (Physics.Linecast (transform.position, chaseTarget.position, sightBlockingLayers)) {
			currentState = AiState.PATROL;
		}
	}





}

