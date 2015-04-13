using UnityEngine;
using System.Collections;

public class AlienB : MonoBehaviour {

	private Animator animator;

	private bool readyAttack;

	void Start() {
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Player") {
			if (readyAttack){
				var explode = target.GetComponent<Explode>() as Explode;
				explode.OnExplode();
			} else {
				animator.SetInteger ("AnimState", 1);
			}
		}
	}

	void OnTriggerExit2D(Collider2D target) {
		readyAttack = false;
		animator.SetInteger ("AnimState", 0);
	}

	void Attack() {
		readyAttack = true;
	}
}
