using UnityEngine;
using System.Collections;

public class trackThin : MonoBehaviour {

	private float thinFactor = 12f;
	private float startThinning = 1f;
	private float stopThinning = 21f;
	private Vector3 startingScale = new Vector3(4.5f,1.0f,0.68f);

	void Start () {
		transform.localScale = startingScale;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.timeSinceLevelLoad > startThinning) && ( Time.timeSinceLevelLoad < stopThinning)){
			transform.localScale = new Vector3 (startingScale.x - (Time.timeSinceLevelLoad - startThinning) / thinFactor, startingScale.y, startingScale.z);
		}
	}
}
