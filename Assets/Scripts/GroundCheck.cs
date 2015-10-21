using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
	private PlayerControl player;
	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<PlayerControl> ();
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		player.grounded = true;
	}
	void OnTriggerStay2D(Collider2D collider) {
		player.grounded = true;
	}
	void OnTriggerExit2D(Collider2D collider) {
		player.grounded = false;
	}
}
