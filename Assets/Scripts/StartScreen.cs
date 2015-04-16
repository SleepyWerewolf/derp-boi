using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {
	
	public int startScene;
	public int creditsScene;

	private bool loadLock; // to make sure player doesn't load a bunch of scenes

	void OnTriggerEnter2D(Collider2D target) {
		if (tag == "StartGame") {
			LoadScene(startScene);
		}

		if (tag == "Credits") {
			LoadScene(creditsScene);
		}
	}

	void LoadScene(int scene) {
		loadLock = true;
		Application.LoadLevel (scene);
	}
}
