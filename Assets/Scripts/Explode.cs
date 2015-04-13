using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public BodyPart bodyPart;
	public int totalParts = 5;

	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Deadly") {
			OnExplode();
		}
	}

	void OnCollision2d(Collision2D target) {
		if (target.gameObject.tag == "Deadly") {
			OnExplode();
		}
	}

	public void OnExplode() {
		Destroy (gameObject);

		var t = transform;

		for (int i=0; i < totalParts; i++) {
			t.TransformPoint (0, -100, 0);
			BodyPart clone = Instantiate(bodyPart, t.position, Quaternion.identity) as BodyPart;
			clone.rigidbody2D.AddForce (Vector3.right * Random.Range (-50, 50));
			clone.rigidbody2D.AddForce (Vector3.up * Random.Range (100, 400));
		}

		GameObject click = new GameObject ("ClickToContinue");
		ClickToContinue script = click.AddComponent<ClickToContinue> ();
		script.scene = Application.loadedLevelName;	// reload level
		click.AddComponent<DisplayRestartText>();
	}
}
