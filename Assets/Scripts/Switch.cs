using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	private Animator animator;
	public Door door;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target) {
		animator.SetInteger ("AnimState", 1);
		door.Open ();
	}

	void OnTriggerExit2D(Collider2D target) {
		animator.SetInteger ("AnimState", 2);
		door.Close ();
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawLine (transform.position, door.transform.position);
	}
}
