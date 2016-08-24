using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 10f;

	private Transform target;
	private int waypointIndex = 0;

	void Start(){
		target = Waypoints.waypoints [waypointIndex];
		waypointIndex++;
	}

	void Update(){
		transform.position = Vector3.MoveTowards (transform.position, target.position, Time.deltaTime * speed);

		if (transform.position == target.position) {
			GetNextWaypoint ();
		}
	}

	void GetNextWaypoint(){
		if (waypointIndex > Waypoints.waypoints.Length - 1) {
			Destroy (gameObject);
			return;
		}

		target = Waypoints.waypoints [waypointIndex];
		waypointIndex++;
	}

}
