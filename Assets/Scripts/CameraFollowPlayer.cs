using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject target;
	private Transform _t;

	// Use this for initialization
	void Start () {
		_t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (_t)
			transform.position = new Vector3 (_t.position.x, _t.position.y + 2f, transform.position.z);
	}
}
