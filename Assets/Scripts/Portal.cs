using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public Portal targetPortal;
	public GameObject player;
	
	public bool isBottom;
	public bool isTop;
	public bool isRight;
	public bool isLeft;

	private float adjust = 1f;
	private float localScaleX = 0f;
	public float portalThrust = 1000f;

	//	Portal dynamically realigns itself based
	//	on the surface it hits
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");

		gameObject.transform.rotation = Quaternion.identity;
		if (isTop) {
			if (player.transform.localScale.x < 0)
				transform.Rotate (Vector3.forward * 90);
			else transform.Rotate (Vector3.forward * -90);
		} else if (isBottom) {
			if (player.transform.localScale.x < 0)
				transform.Rotate (Vector3.forward * -90);
			else transform.Rotate (Vector3.forward * 90);
		} else if (isRight) {
			transform.Rotate (Vector3.forward * 180);
		} else if (isLeft) {
			transform.Rotate (Vector3.forward * -180);
		}

		if (tag == "BluePortal" && GameObject.FindGameObjectWithTag("OrangePortal")) {
			targetPortal = GameObject.FindGameObjectWithTag("OrangePortal").GetComponent<Portal>();
		} else if (tag == "OrangePortal" && GameObject.FindGameObjectWithTag("BluePortal")) {
			targetPortal = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Portal>();
		}
	}

	// In case only one portal is in existence
	void Update() {
		if (tag == "BluePortal" && GameObject.FindGameObjectWithTag("OrangePortal")) {
			targetPortal = GameObject.FindGameObjectWithTag("OrangePortal").GetComponent<Portal>();
		} else if (tag == "OrangePortal" && GameObject.FindGameObjectWithTag("BluePortal")) {
			targetPortal = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Portal>();
		}

		if (Input.GetMouseButtonDown(2)) {
			var orangePortals = GameObject.FindGameObjectWithTag("OrangePortal");
			var bluePortals = GameObject.FindGameObjectWithTag("BluePortal");
			Destroy(orangePortals);
			Destroy(bluePortals);
		}
	}

	// 	Portal dynamically thrusts the target in the opposite direction
	//	based on the portal's positioning
	void OnTriggerEnter2D(Collider2D target) {
		if (targetPortal && target.tag != "BlueShot" && target.tag != "OrangeShot") {
			localScaleX = targetPortal.transform.localScale.x > 0 ? -1 : 1;
			if (targetPortal.isTop) {
				target.gameObject.transform.position = new Vector3(targetPortal.transform.position.x, targetPortal.transform.position.y - 1f, 0);
				target.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -portalThrust));
			} else if (targetPortal.isBottom) {
				target.gameObject.transform.position = new Vector3(targetPortal.transform.position.x, targetPortal.transform.position.y + 1f, 0);
				target.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, portalThrust));	
			} else {
				target.gameObject.transform.position = new Vector3(targetPortal.transform.position.x + (-targetPortal.transform.localScale.x * adjust), targetPortal.transform.position.y, 0);
				target.gameObject.transform.localScale = new Vector3(localScaleX, 1, targetPortal.transform.localScale.z);
				target.GetComponent<Rigidbody2D>().AddForce(new Vector2(localScaleX * portalThrust, 0));
			}
		}
	}
}
