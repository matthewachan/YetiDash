using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	// Public variables
	public float moveSpeed = 5;
	public float jumpForce = 600;
	public bool grounded;

	// PHYSICS
	private Rigidbody2D rb;
	private Vector2 velocity;

	// FLAGS
	private bool faceRight = true;

	// ANIMATION
	private Animator anim;
	private int runBool = Animator.StringToHash("Running");
	private int jumpTrig = Animator.StringToHash("Jumping");
	private int groundBool = Animator.StringToHash("Grounded");


	// Initializations
	void Awake() {
		StartCoroutine (ShowMessage ("Level 1", 2));
		rb = gameObject.GetComponent<Rigidbody2D>(); 
		anim = gameObject.GetComponent<Animator> ();
	}
	IEnumerator ShowMessage (string message, float delay) {
		GUIText guiText = new GUIText ();
		guiText.text = message;
		guiText.enabled = true;
		yield return new WaitForSeconds (delay);
		guiText.enabled = false;
	}
	// Physics
	void Update () {

		// Move player
		float horiz = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2 (horiz * moveSpeed, rb.velocity.y);

		// Check if player is on the ground
		anim.SetBool (groundBool, grounded);

		// Player jumps on button press
		if (Input.GetButtonDown ("Jump") && grounded) {
			anim.SetTrigger (jumpTrig);
			rb.AddForce (new Vector2 (rb.velocity.x, jumpForce));
		}

		// Run animation
		if (Mathf.Abs (horiz) > 0)
			anim.SetBool (runBool, true);
		else if (Mathf.Abs (horiz) == 0) {
			anim.SetBool (runBool, false);
		}

		// Reverse player direction
		if (horiz > 0 && !faceRight) {
			Flip();
		} else if (horiz < 0 && faceRight) {
			Flip();
		}
	}
	
	// Changes the direction of the player object
	void Flip() {
		faceRight = !faceRight;
		Vector3 flip = transform.localScale;
		flip.x *= -1;
		transform.localScale = flip;
	}

	void OnGUI() {
		GUIStyle txtSet = new GUIStyle ();
		txtSet.fontSize = 100;
		if (Time.time <= 3) 
			GUI.Label (new Rect (5, 0, 500, 500), "LEVEL 1", txtSet);
	}
}
