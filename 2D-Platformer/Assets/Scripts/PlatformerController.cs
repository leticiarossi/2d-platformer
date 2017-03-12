	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to control jumping of the player and animations.
 * Most of the code is from the script from class.
 */ 

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
	public AudioClip jumpSound;

	AudioSource source;
	Rigidbody2D rb2d;
	Animator anim;
	bool grounded;

	float lostGroundingTime;
	float lastJumpTime;
	float lastInputJump;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = CheckGrounded ();
		ApplyHorizontalInput ();
		// Disconnect player from moving platform if player left it
		RemoveFromMovingPlatform ();
		if (CheckJumpInput () && PermissionToJump ()) {
			Jump ();
			// Play jump sound
			source.clip = jumpSound;
			source.volume = 0.56f;
			source.pitch = 1.33f;
			source.PlayOneShot (jumpSound);
		}
		UpdateAnimations ();
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

	void UpdateAnimations () {
		anim.SetBool ("grounded", grounded);
		anim.SetFloat ("speed", Mathf.Abs (rb2d.velocity.x));
		if (lastJumpTime == Time.time) {
			anim.SetTrigger ("jump");
		}
		if (Input.GetButton ("PickUpBlock") || Input.GetButton ("PlaceBlock")) {
			anim.SetTrigger ("crouched");
		} 
	}

	void RemoveFromMovingPlatform () {
		if (transform.parent != null && !grounded) {
			transform.parent = null;
		}
	}
}
