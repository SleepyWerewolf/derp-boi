using UnityEngine;
using System.Collections;

public class PortalGun : MonoBehaviour {
	
	public Shot blueShot, orangeShot;
	private GameObject player;
	private float directionalAdjust = 1f;

	// Update is called once per frame
	void Update () {
		// Rotate up
		if (Input.GetKeyDown("w")) {
			transform.Rotate (Vector3.forward * -90);
			/*
			if (Input.GetKeyDown("d")) {
				transform.Rotate (Vector3.forward * -45);
			} if (Input.GetKeyUp("d")) transform.Rotate (Vector3.forward * 45);
			
			if (Input.GetKeyDown("a")) {
				transform.Rotate (Vector3.forward * 45);
			}  if (Input.GetKeyUp("a")) transform.Rotate (Vector3.forward * -45);
			*/

		} if (Input.GetKeyUp("w")) transform.Rotate (Vector3.forward * 90);

		// Rotate down
		if (Input.GetKeyDown("s")) {
			transform.Rotate (Vector3.forward * 90);
		} if (Input.GetKeyUp("s")) transform.Rotate (Vector3.forward * -90);

		if (Input.GetMouseButtonDown(0)) {
			Shot shot = Instantiate (blueShot, transform.position, transform.rotation) as Shot;
		} else if (Input.GetMouseButtonDown(1)) {
			Shot shot = Instantiate (orangeShot, transform.position, transform.rotation) as Shot;
		}
	}
}


/*
		Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 direction = Input.mousePosition - position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
*/