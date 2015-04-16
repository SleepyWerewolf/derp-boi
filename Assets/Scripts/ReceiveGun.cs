using UnityEngine;
using System.Collections;

public class ReceiveGun : MonoBehaviour {

	public Player player;

	// Replaces jetpack model of player
	// with portal gun model
	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Player") {
			Player newPlayer = Instantiate (player, target.transform.position, target.transform.rotation) as Player;
			Destroy(target.gameObject);
			Destroy(gameObject);
		}
	}
}
