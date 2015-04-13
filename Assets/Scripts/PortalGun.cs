using UnityEngine;
using System.Collections;

public class PortalGun : MonoBehaviour {
	
	public Shot blueShot, orangeShot;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Shot shot = Instantiate (blueShot, transform.position, transform.rotation) as Shot;
		}
		else if (Input.GetMouseButtonDown(1)) {
			Shot shot = Instantiate (orangeShot, transform.position, transform.rotation) as Shot;
		}
	}
}
