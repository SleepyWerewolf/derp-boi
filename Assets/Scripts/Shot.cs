using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public float speed = 20f;
	private float spacialAdjust = 0.5f;
	private float directionalAdjust = 1f;
	private float horizontalAdjust = 1f;
	private bool isDownShot;
	public Portal bluePortal, orangePortal;

	private GameObject player;
	private Vector2 direction;

	void Start() {
		isDownShot = false;

		// Get player object
		player = GameObject.FindGameObjectWithTag("Player");

		// Determine direction of shot
		if (player.transform.localScale.x < 0) {
			transform.localScale = -transform.localScale;
			spacialAdjust = -spacialAdjust;
			directionalAdjust = -directionalAdjust;
		}

		if (Input.GetKey("e") && player.transform.localScale.x > 0) {
			transform.position = new Vector3 (transform.position.x + .5f, transform.position.y + .5f, transform.position.z);
			direction = new Vector2 (transform.localScale.x, transform.localScale.y);
		} 

		else if (Input.GetKey("q") && player.transform.localScale.x < 0) {
			transform.position = new Vector3 (transform.position.x - .5f, transform.position.y + .5f, transform.position.z);
			direction = new Vector2 (transform.localScale.x, -transform.localScale.y);
		} 

		else if (Input.GetKey("w")) {
			// Prevent shot from colliding with floor
			transform.position = new Vector3 (transform.position.x, transform.position.y + .5f, transform.position.z);
			direction = new Vector2 (0, directionalAdjust * transform.localScale.y);
			if (player.transform.localScale.x < 0) {
				transform.Rotate (Vector3.forward * 180);
				horizontalAdjust = -horizontalAdjust;
			} 
		} 

		else if (Input.GetKey("s")) {
			isDownShot = true;
			direction = new Vector2 (0, -(directionalAdjust * transform.localScale.y));
			if (player.transform.localScale.x < 0) {
				transform.Rotate (Vector3.forward * 180);
				horizontalAdjust = -horizontalAdjust;
			}
		} 

		else if ((Input.GetKey("a") && Input.GetKey("s")) || (Input.GetKey("s") && Input.GetKey("d"))) {
			direction = new Vector2 (transform.localScale.x, -(directionalAdjust * transform.localScale.y));
		} else direction = new Vector2 (transform.localScale.x, 0);

		// Destroy after 10 sec to prevent memory leak
		Destroy(gameObject, 10);
	}

	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = direction * speed;
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "VerticalWall") {
			if (tag == "BlueShot") {
				GameObject bluePortals = GameObject.FindGameObjectWithTag("BluePortal");
				Destroy(bluePortals);
				var portalPosition = new Vector3(transform.position.x + spacialAdjust, transform.position.y, transform.position.z);
				Portal portal = Instantiate (bluePortal, portalPosition, transform.rotation) as Portal;
				portal.transform.localScale = transform.localScale;
				Destroy(gameObject);
				portal.isHorizontal = false;
			} else if (tag == "OrangeShot") {
				GameObject orangePortals = GameObject.FindGameObjectWithTag("OrangePortal");
				Destroy(orangePortals);
				var portalPosition = new Vector3(transform.position.x + spacialAdjust, transform.position.y, transform.position.z);
				Portal portal = Instantiate (orangePortal, portalPosition, transform.rotation) as Portal;
				portal.transform.localScale = transform.localScale;
				Destroy(gameObject);
				portal.isHorizontal = false;
			}
		} else if (target.tag == "HorizontalWall") {
			float portalPositionY;
			if (tag == "BlueShot") {
				GameObject bluePortals = GameObject.FindGameObjectWithTag("BluePortal");
				Destroy(bluePortals);
				if (isDownShot) {
					portalPositionY = transform.position.y - (horizontalAdjust * spacialAdjust);
				}
				else {
					portalPositionY = transform.position.y + (horizontalAdjust * spacialAdjust);
				}
				var portalPosition = new Vector3(transform.position.x, portalPositionY, transform.position.z);
				Portal portal = Instantiate (bluePortal, portalPosition, transform.rotation) as Portal;
				portal.transform.localScale = transform.localScale;
				Destroy(gameObject);
				portal.isHorizontal = true;
			}
			if (tag == "OrangeShot") {
				GameObject orangePortals = GameObject.FindGameObjectWithTag("OrangePortal");
				Destroy(orangePortals);
				if (isDownShot) {
					portalPositionY = transform.position.y - (horizontalAdjust * spacialAdjust);
				} else {
					portalPositionY = transform.position.y + (horizontalAdjust * spacialAdjust);
				}
				var portalPosition = new Vector3(transform.position.x, portalPositionY, transform.position.z);
				Portal portal = Instantiate (orangePortal, portalPosition, transform.rotation) as Portal;
				portal.transform.localScale = transform.localScale;
				Destroy(gameObject);
				portal.isHorizontal = true;
			}
		}
	}
}
