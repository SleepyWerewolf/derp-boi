using UnityEngine;
using System.Collections;

public class PortalGun : MonoBehaviour {
	
	public Shot blueShot, orangeShot;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Shot shot = Instantiate (blueShot, transform.position, transform.rotation) as Shot;
		} else if (Input.GetMouseButtonDown(1)) {
			Shot shot = Instantiate (orangeShot, transform.position, transform.rotation) as Shot;
		} else if (Input.GetKey("e")) {
			Debug.Log("Hello");
		}
/*
		Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 direction = Input.mousePosition - position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
*/
	}
}
