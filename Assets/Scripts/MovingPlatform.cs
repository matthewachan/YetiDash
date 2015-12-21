using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	private Rigidbody2D rb;
	private double startPos;
	private bool up = true;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		startPos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.position.y >= startPos + 1)
			up = false;
		if (rb.position.y <= startPos - 1)
			up = true;

	}
	void FixedUpdate() {
		if (up) 
			rb.velocity = new Vector2 (0, 1);
		else
			rb.velocity = new Vector2 (0, -1);
	}
}
