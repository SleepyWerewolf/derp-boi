using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {

	public Sprite[] sprites;	
	public string resourceName;
	public int currentSprite = -1; // represents ID in sprite array that overrides random function

	// Use this for initialization
	void Start () {
		if (resourceName != "") {
			// Load sprites coming from Resources folder
			sprites = Resources.LoadAll<Sprite> (resourceName);

			if (currentSprite == -1)
				currentSprite = Random.Range (0, sprites.Length);
			else if (currentSprite > sprites.Length)
				currentSprite = sprites.Length - 1;

			// Randomly grab one of the sprites
			GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
		}
	}
}
