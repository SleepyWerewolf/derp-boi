using UnityEngine;
using System.Collections;

public class PersistantMusic : MonoBehaviour {

	// 	Allows music to keep playing while progressing
	//	through levels
	void Start () {
		DontDestroyOnLoad(gameObject);
	}

	void Update() {
		if (Application.loadedLevel == 4) {
			Destroy(gameObject);
		}
	}
	
}
