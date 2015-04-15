using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public GameObject targetPortal;
	public GameObject player;
	
	public bool isBottom;
	public bool isTop;
	private float adjust = 1f;
	private float localScaleX = 0f;
	public float portalThrust = 250f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");

		if (isTop) {
			gameObject.transform.rotation = Quaternion.identity;
			if (player.transform.localScale.x < 0)
				transform.Rotate (Vector3.forward * 90);
			else transform.Rotate (Vector3.forward * -90);
		} else if (isBottom) {
			gameObject.transform.rotation = Quaternion.identity;
			if (player.transform.localScale.x < 0)
				transform.Rotate (Vector3.forward * -90);
			else transform.Rotate (Vector3.forward * 90);
		}

		if (tag == "BluePortal") {
			targetPortal = GameObject.FindGameObjectWithTag("OrangePortal");
		} else if (tag == "OrangePortal") {
			targetPortal = GameObject.FindGameObjectWithTag("BluePortal");
		}
	}

	// In case only one portal is in existence
	void Update() {
		if (tag == "BluePortal") {
			targetPortal = GameObject.FindGameObjectWithTag("OrangePortal");
		} else if (tag == "OrangePortal") {
			targetPortal = GameObject.FindGameObjectWithTag("BluePortal");
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (targetPortal && target.tag != "BlueShot" && target.tag != "OrangeShot") {
			if (isTop || isBottom) {
				localScaleX = targetPortal.transform.localScale.x > 0 ? -1 : 1;
				target.gameObject.transform.position = new Vector3(targetPortal.transform.position.x + (-targetPortal.transform.localScale.x * adjust), targetPortal.transform.position.y, 0);
				target.gameObject.transform.localScale = new Vector3(localScaleX, 1, targetPortal.transform.localScale.z);
				target.rigidbody2D.AddForce(new Vector2(localScaleX * portalThrust, 50f));
			} else {
				localScaleX = targetPortal.transform.localScale.x > 0 ? -1 : 1;
				target.gameObject.transform.position = new Vector3(targetPortal.transform.position.x + (-targetPortal.transform.localScale.x * adjust), targetPortal.transform.position.y, 0);
				target.gameObject.transform.localScale = new Vector3(localScaleX, 1, targetPortal.transform.localScale.z);
				target.rigidbody2D.AddForce(new Vector2(localScaleX * portalThrust, 50f));
			}
		}
	}
}
