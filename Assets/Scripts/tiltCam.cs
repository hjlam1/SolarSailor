using UnityEngine;
using System.Collections;

public class tiltCam : MonoBehaviour {

	private float tiltFactor = -35.0f;
	private float lastTilt = 0f;
	private float tiltSpeed = 0.5f;

	void Start () {
		transform.rotation = Quaternion.identity;
	
	}
	
	// Update is called once per frame
	void Update () {
		lastTilt = (float)Input.GetAxis("Horizontal") * tiltFactor;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, lastTilt), tiltSpeed); 

	}

	void OnGUI() {
		//GUILayout.Box ("zRot: " + transform.eulerAngles.z);
		//GUILayout.Box ("tilt: " + lastTilt);

	}
}
