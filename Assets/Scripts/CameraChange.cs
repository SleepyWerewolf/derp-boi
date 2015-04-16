using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour {

	private GameObject camera;

	void Start() {
		camera = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void OnTriggerStay2D(Collider2D target) {
		if (target.tag == "Player") {
			camera.transform.position = new Vector3 (transform.position.x, transform.position.y, -10);
		}
	}
}
