using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	private int i;
	void Start() {
		i = Application.loadedLevel;
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			Application.LoadLevel(i+1);
		}
	}
}
