using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebotin : MonoBehaviour {

	float force = 1000;

	void OnCollisionEnter2D (Collision2D other) {
		other.gameObject.GetComponent<Rigidbody2D>().AddForce (transform.up * force);

	}

}
