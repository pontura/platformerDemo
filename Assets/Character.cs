using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;// = 360f;
	public float maxSpeed;//  = 5f;
	public float jumpForce;//  = 500f;
	public float jumpSecondFactor;//  = 250f;
	bool jump;
	public bool grounded;
	public Transform groundCheck;
	public int jumps;

	float lastTimeOnFloor;
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2(h*speed, rb.velocity.y);
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Floor"));
		if (Time.time > lastTimeOnFloor + 0.2f && grounded)
			jumps = 0;
		if (Input.GetButtonDown ("Jump") && grounded == true && jumps == 0) {
			lastTimeOnFloor = Time.time;
			rb.AddForce (new Vector2(0f, jumpForce));
			jumps = 1;
		} else if (Input.GetButtonDown ("Jump") && jumps == 1) {
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.AddForce (new Vector2(0f, jumpForce*jumpSecondFactor));
			jumps = 2;
		}
	}
}
