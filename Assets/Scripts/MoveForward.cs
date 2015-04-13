using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float speed = 0.5f;

	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (transform.localScale.x, 0) * speed;
	}
}
