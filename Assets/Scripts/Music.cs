using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public AudioSource track1;
	public AudioSource track2;

	void Start () {
		track1.Play();
		Invoke("PlayTrack2", track1.clip.length);
	}

	// Allows looping
	void PlayTrack2() {
		track2.Play();
	}
}
