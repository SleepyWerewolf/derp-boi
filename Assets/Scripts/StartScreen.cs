using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {
	
	public int startScene;
	public int creditsScene;

	// Loads level based on what the player shoots
	void OnTriggerEnter2D(Collider2D target) {
		if (tag == "StartGame") {
			LoadScene(startScene);
		}

		if (tag == "Credits") {
			LoadScene(creditsScene);
		}
	}

	void LoadScene(int scene) {
		Application.LoadLevel (scene);
	}
}
