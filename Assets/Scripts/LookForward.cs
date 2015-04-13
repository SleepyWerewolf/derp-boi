using UnityEngine;
using System.Collections;

public class LookForward : MonoBehaviour {

	public Transform sightStart, sightEnd;

	public bool needsCollision = true;
	public bool collision = false;
	
	// Update is called once per frame
	void Update () {
		collision = Physics2D.Linecast(sightStart.position, 
		                               sightEnd.position, 
		                               1 << LayerMask.NameToLayer("Solid"));
		if (collision == needsCollision)
			this.transform.localScale = new Vector3 ((transform.localScale.x == 1) ? -1 : 1, 1, 1);
	}
}
