using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = .3f;

	private Animator animator;
	private PlayerController controller;

	void Start() {
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}

	void Update () {
		float forceX = 0f;
		float forceY = 0f;

		// Determine what direction player is moving
		var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
		var absVelY = Mathf.Abs (rigidbody2D.velocity.y);
		bool xVelocity = absVelX < maxVelocity.x;
		bool yVelocity = absVelY < maxVelocity.y;

		standing = absVelY < .2f ? true : false;

		// Horizontal movement
		if (controller.direction.x != 0) {
			if (xVelocity) {
				forceX = standing ? speed * controller.direction.x : (speed * controller.direction.x * airSpeedMultiplier);
				transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);
			}
			animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger ("AnimState", 0);
		}

		// Vertical movement
		if (controller.direction.y > 0) {
			if (yVelocity) {
				if (!controller.canFly) {
					if (standing)
						forceY = jetSpeed * controller.direction.y;
				} else forceY = jetSpeed * controller.direction.y;
			}
			animator.SetInteger ("AnimState", 2);
		} else if (absVelY > 0) {
			animator.SetInteger ("AnimState", 3);
		}

		rigidbody2D.AddForce(new Vector2(forceX, forceY));
	}
}
