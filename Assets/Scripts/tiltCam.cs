using UnityEngine;
using System.Collections;

public class tiltCam : MonoBehaviour {

	private float tiltFactor = -15.0f;
	//public float mouseTiltFactor = 1.0f;
	private float lastTilt = 0f;
	private float tiltSpeed = 0.5f;
	private Quaternion tilt = Quaternion.identity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lastTilt = (float)Input.GetAxis("Horizontal") * tiltFactor;

		//float rotation = Input.GetAxis("Horizontal") * tiltFactor;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, lastTilt), tiltSpeed); 
		//transform.eulerAngles = Vector3.Lerp (transform.eulerAngles,new Vector3( transform.eulerAngles.x, transform.eulerAngles.y, lastTilt * tiltFactor), Time.deltaTime);
		//transform.Rotate(0, 0, lastTilt);
		
		//float h = mouseTiltFactor * Input.GetAxis("Mouse X");
		//transform.Rotate(0, h, 0);
	}

	void OnGUI() {
		GUILayout.Box ("zRot: " + transform.eulerAngles.z);
		GUILayout.Box ("tilt: " + lastTilt);
	}
}
