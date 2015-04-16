using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour {

	public int scene;

	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Player") {
			Destroy (target.gameObject);
			Application.LoadLevel (scene);
		}
	}
}
