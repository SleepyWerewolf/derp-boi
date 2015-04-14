using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public float speed = 20f;
	private float spacialAdjust = 0.5f;
	private float directionalAdjust = 1f;
	public Portal bluePortal, orangePortal;

	private GameObject player;
	private Vector2 direction;

	void Start() {
		// Get player object
		player = GameObject.FindGameObjectWithTag("Player");

		// Determine direction of shot
		if (player.transform.localScale.x < 0) {
			transform.localScale = -transform.localScale;
			spacialAdjust = -spacialAdjust;
			directionalAdjust = -directionalAdjust;
		}

		if (Input.GetKey("e") && player.transform.localScale.x > 0) {
			direction = new Vector2 (transform.localScale.x, transform.localScale.y);
		} else if (Input.GetKey("q") && player.transform.localScale.x < 0) {
			direction = new Vector2 (transform.localScale.x, -transform.localScale.y);
		} else if (Input.GetKey("w")) {
			direction = new Vector2 (0, directionalAdjust * transform.localScale.y);
		} else if (Input.GetKey("s")) {
			direction = new Vector2 (0, -(directionalAdjust * transform.localScale.y));
		} else direction = new Vector2 (transform.localScale.x, 0);

		// Destroy after 10 sec to prevent memory leak
		Destroy(gameObject, 10);
	}

	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = direction * speed;
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "PortalEnabled") {
			if (tag == "BlueShot") {
				GameObject bluePortals = GameObject.FindGameObjectWithTag("BluePortal");
				Destroy(bluePortals);
				var portalPosition = new Vector3(transform.position.x + spacialAdjust, transform.position.y, transform.position.z);
				Portal portal = Instantiate (bluePortal, portalPosition, transform.rotation) as Portal;
				portal.transform.localScale = transform.localScale;
				Destroy(gameObject);
			} else if (tag == "OrangeShot") {
				GameObject orangePortals = GameObject.FindGameObjectWithTag("OrangePortal");
				Destroy(orangePortals);
				var portalPosition = new Vector3(transform.position.x + spacialAdjust, transform.position.y, transform.position.z);
				Portal portal = Instantiate (orangePortal, portalPosition, transform.rotation) as Portal;
				portal.transform.localScale = transform.localScale;
				Destroy(gameObject);
			}
		}
	}
}
