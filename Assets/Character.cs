using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public Animator anim;
	public int coins;
	public Rigidbody2D rb;
	public float speed;// = 360f;
	public float maxSpeed;//  = 5f;
	public float jumpForce;//  = 500f;
	public float jumpSecondFactor;//  = 250f;
	bool jump;
	public bool grounded;
	public Transform groundCheck;
	public int jumps;

	public states state;
	public enum states
	{
		IDLE,
		WALKING,
		JUMP,
		REACH_FLOOR
	}

	float lastTimeOnFloor;
	void Update () {
		float h = Input.GetAxis ("Horizontal");

		if (h < 0)
			transform.localScale = new Vector3 (-1, 1, 1);
		else if (h > 0)
			transform.localScale = new Vector3 (1, 1, 1);

		if (h != 0) {
			Walk ();
		} else {
			Idle ();
		}
		
		rb.velocity = new Vector2(h*speed, rb.velocity.y);
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Floor"));
		if (Time.time > lastTimeOnFloor + 0.2f && grounded) {
			state = states.REACH_FLOOR;
			jumps = 0;
		}
		if (Input.GetButtonDown ("Jump") && grounded == true && jumps == 0) {
			Jump ();
			lastTimeOnFloor = Time.time;
			rb.AddForce (new Vector2(0f, jumpForce));
			jumps = 1;
		} else if (Input.GetButtonDown ("Jump") && jumps == 1) {
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.AddForce (new Vector2(0f, jumpForce*jumpSecondFactor));
			jumps = 2;
		}
	}
	public void Die()
	{
		print ("die");
	}
	void Walk()
	{
		if (state == states.WALKING)
			return;
		state = states.WALKING;

		anim.Play ("walk");
	}
	void Idle()
	{
		if (state == states.IDLE || state == states.JUMP)
			return;
		state = states.IDLE;

		anim.Play ("idle");
	}
	void Jump()
	{
		if (state == states.JUMP)
			return;
		state = states.JUMP;

		anim.Play ("jump");
		Events.OnSoundFX ("sounds/jump");
	}
}
