using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlatformerController : MonoBehaviour {

	public Vector2 input;
	public bool inputJump;

	public float speed = 5;
	public float jumpVelocity = 15;
	public float gravity = 40;
	public float groundingTolerance = .1f;
	public float jumpingTolerance = .1f;

	public CircleCollider2D groundCollider;
	public LayerMask groundLayers;

	int sizeOfPlayer = 1; // Number of blocks that player is made of
	Rigidbody2D rb2d;
	SpriteRenderer sr;
	bool grounded;

	float lostGroundingTime;
	float lastJumpTime;
	float lastInputJump;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = CheckGrounded ();
		ApplyHorizontalInput ();
		if (CheckJumpInput () && PermissionToJump ()) {
			Jump ();
		}
	}

	void ApplyHorizontalInput () {
		Vector2 newVelocity = rb2d.velocity;
		newVelocity.x = input.x * speed;
		newVelocity.y += -gravity * Time.deltaTime;
		rb2d.velocity = newVelocity;
	}

	void Jump () {
		rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpVelocity);
		lastJumpTime = Time.time;
		grounded = false;
	}

	bool CheckGrounded ()
	{
		if (groundCollider.IsTouchingLayers (groundLayers)) {
			lostGroundingTime = Time.time;
			return true;
		}
		return false;
	}

	bool PermissionToJump () {
		bool wasJustgrounded = Time.time < lostGroundingTime + groundingTolerance;
		bool hasJustJumped = Time.time < lastJumpTime + groundingTolerance + Time.deltaTime;
		return (grounded || wasJustgrounded) && !hasJustJumped;
	}

	bool CheckJumpInput () {
		if (inputJump) {
			lastInputJump = Time.time;
			return true;
		}
		if (Time.time < lastInputJump + jumpingTolerance) {
			return true;
		}
		return false;
	}
}
