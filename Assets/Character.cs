using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public Rigidbody2D rb;
	public float moveForce;// = 360f;
	public float maxSpeed;//  = 5f;
	public float jumpForce;//  = 500f;
	public float jumpSecondFactor;//  = 250f;
	bool jump;
	public bool grounded;
	public Transform groundCheck;
	public int jumps;

	float lastTimeOnFloor;
	void Update () {
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Floor"));
		if (Time.time > lastTimeOnFloor + 0.2f && grounded)
			jumps = 0;
		if (Input.GetButtonDown ("Jump") && grounded == true && jumps == 0) {
			lastTimeOnFloor = Time.time;
			jump = true;
			jumps = 1;
		} else if (Input.GetButtonDown ("Jump") && jumps == 1) {
			rb.velocity = new Vector2(rb.velocity.x, 0);
			jump = true;
			jumps = 2;
		}

	}

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		print (h);

		if(h * rb.velocity.x < maxSpeed)
			rb.AddForce (Vector2.right * h * moveForce);

		if(Mathf.Abs(rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

		if (jump) {
			if(jumps == 1)
				rb.AddForce (new Vector2(0f, jumpForce));
			else
				rb.AddForce (new Vector2(0f, jumpForce*jumpSecondFactor));
			jump = false;
		}
	}
}
