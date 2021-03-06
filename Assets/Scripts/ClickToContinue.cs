﻿using UnityEngine;
using System.Collections;

public class ClickToContinue : MonoBehaviour {

	public string scene;
	private bool loadLock; // to make sure player doesn't load a bunch of scenes
	
	// Reload scene once player dies
	void Update () {
		if (Input.GetMouseButtonDown (0) && !loadLock)
			LoadScene ();
	}

	void LoadScene() {
		loadLock = true;
		Application.LoadLevel (scene);
	}
}
