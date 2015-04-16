using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public const int IDLE = 0;
	public const int OPENING = 1;
	public const int OPEN = 2;
	public const int CLOSING = 3;

	public float closeDelay = 0.5f;
	private int state = IDLE;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Various states used by animator
	// to allow player to enter
	void OnOpenStart() {
		state = OPENING;
	}

	void OnOpenEnd() {
		state = OPEN;
	}

	void OnCloseStart() {
		state = CLOSING;
	}

	void OnCloseEnd() {
		state = IDLE;
	}

	void DisableCollider2D() {
		collider2D.enabled = false;
	}

	void EnableCollider2D() {
		collider2D.enabled = true;
	}

	// 	Change tags to allow Portal Shot to go through
	//	an open door
	public void Open() {
		animator.SetInteger ("AnimState", 1);
		if (tag != "AntiPortalDoor") {
			tag = "PortalEnabled";
		}
	}

	public void Close() {
		StartCoroutine (CloseNow ());
	}

	// 	Change tags to prevent shots
	// 	going through an open door
	private IEnumerator CloseNow() {
		yield return new WaitForSeconds (closeDelay);
		animator.SetInteger ("AnimState", 2);
		if (tag != "AntiPortalDoor") {
			tag = "PortalDisabled";
		}
	}

}
