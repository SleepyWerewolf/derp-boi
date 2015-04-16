using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public bool canFly;
	public Vector2 direction = new Vector2();

	// Update is called once per frame
	void Update () {
		
		direction.x = direction.y = 0;
		
		if (Input.GetKey ("d") || Input.GetKey ("right")) {
			direction.x = 1;
		} else if (Input.GetKey ("a") || Input.GetKey ("left")) {
			direction.x = -1;
		}
		
		//	Makes the adjustment based on whether the active player
		//	is using the portal gun model or the jetpack model
		if (canFly) {
			if (Input.GetKey ("space") || Input.GetKey("up")) {
				direction.y = 1;
			}
		} else {
			if (Input.GetKeyDown ("space")) {
				direction.y = 1;
			}
		}
		
	}
}
