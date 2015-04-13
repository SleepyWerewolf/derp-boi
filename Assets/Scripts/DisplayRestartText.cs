using UnityEngine;
using System.Collections;

public class DisplayRestartText : MonoBehaviour {

	private Texture2D restart;

	// Use this for initialization
	void Start () {
		restart = Resources.Load<Texture2D> ("restart-text");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		var x = (Screen.width - restart.width) / 2;
		var y = Screen.height - 50;

		if (Time.time % 2 > 1)
			GUI.DrawTexture (new Rect (x, y, restart.width, restart.height), restart);
	}

}
