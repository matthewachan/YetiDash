using UnityEngine;
using System.Collections;

public class Boundaries : MonoBehaviour {
	private PlayerControl player;
	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		Application.LoadLevel (Application.loadedLevel);
	}

}
