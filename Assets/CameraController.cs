using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public bool Lock_X_axis;
	public GameObject target;
	public Vector3 offset;
	public float speed = 0.05f;

	void Start () {
		
	}

	void Update () {
		Vector3 dest = target.transform.position - offset;
		if (Lock_X_axis) {
			dest.x = 0;
		}
		transform.position = Vector3.Lerp( transform.position, dest, speed);
	}
}
