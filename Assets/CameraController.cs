using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public Vector3 offset;
	public float speed = 0.05f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp( transform.position, target.transform.position - offset, speed);
	}
}
