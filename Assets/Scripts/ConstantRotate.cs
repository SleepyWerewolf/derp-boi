using UnityEngine;
using System.Collections;

public class ConstantRotate : MonoBehaviour {

	public float speed = .5f;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward, 45 * Time.deltaTime * speed);
	}
}
