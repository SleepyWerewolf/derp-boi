using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public float speed = 20f;
	private float direction = 0f;
	private float adjust = 0.5f;
	public Portal bluePortal, orangePortal;

	private GameObject player;

	void Start() {
		// Get player object
		player = GameObject.FindGameObjectWithTag("Player");

		// Determine direction of shot
		if (player.transform.localScale.x < 0) {
			transform.localScale = -transform.localScale;
			adjust = -adjust;
		}

		// Destroy after 10 sec to prevent memory leak
		Destroy(gameObject, 10);
	}

	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (transform.localScale.x, 0) * speed;
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "PortalEnabled") {
			if (tag == "BlueShot") {
				GameObject bluePortals = GameObject.FindGameObjectWithTag("BluePortal");
				Destroy(bluePortals);
				var portalPosition = new Vector3(transform.position.x + adjust, transform.position.y, transform.position.z);
				Portal portal = Instantiate (bluePortal, portalPosition, transform.rotation) as Portal;
				Destroy(gameObject);
			} else if (tag == "OrangeShot") {
				GameObject orangePortals = GameObject.FindGameObjectWithTag("OrangePortal");
				Destroy(orangePortals);
				var portalPosition = new Vector3(transform.position.x + adjust, transform.position.y, transform.position.z);
				Portal portal = Instantiate (orangePortal, portalPosition, transform.rotation) as Portal;
				Destroy(gameObject);
			}
		}
	}
}
