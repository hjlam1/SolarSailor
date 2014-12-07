using UnityEngine;
using System.Collections;

public class trackThin : MonoBehaviour {

	private float thinFactor = 15f;
	private float startThinning = 10f;
	private float stopThinning = 60f;
	private Vector3 startingScale = new Vector3(5.0f,1.0f,0.68f);

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
