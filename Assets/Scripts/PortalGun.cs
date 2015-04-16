using UnityEngine;
using System.Collections;

public class PortalGun : MonoBehaviour {
	
	public Shot blueShot, orangeShot;

	// 	Detects player input in order to rotate gun sprite in proper direction
	void Update () {
		// Rotate up
		if (Input.GetKeyDown("w")) {
			transform.Rotate (Vector3.forward * -90);
		} if (Input.GetKeyUp("w")) transform.Rotate (Vector3.forward * 90);

		// Rotate down
		if (Input.GetKeyDown("s")) {
			transform.Rotate (Vector3.forward * 90);
		} if (Input.GetKeyUp("s")) transform.Rotate (Vector3.forward * -90);

		if (Input.GetKeyDown("e")) {
			transform.Rotate (Vector3.forward * -45);
		} if (Input.GetKeyUp("e")) transform.Rotate (Vector3.forward * 45);

		if (Input.GetKeyDown("q")) {
			transform.Rotate (Vector3.forward * -45);
		} if (Input.GetKeyUp("q")) transform.Rotate (Vector3.forward * 45);

		if (Input.GetMouseButtonDown(0)) {
			Shot shot = Instantiate (blueShot, transform.position, transform.rotation) as Shot;
		} else if (Input.GetMouseButtonDown(1)) {
			Shot shot = Instantiate (orangeShot, transform.position, transform.rotation) as Shot;
		}
	}
}
