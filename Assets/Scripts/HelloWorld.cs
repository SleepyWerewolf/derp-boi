using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HelloWorld : MonoBehaviour {

	public float speed = 2f;

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (speed, 0, transform.position.x) * Time.deltaTime);
	}
}
