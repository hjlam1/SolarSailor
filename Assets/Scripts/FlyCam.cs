using UnityEngine;
using System.Collections;

public class flyCam : MonoBehaviour {
	
	
	public float speed;		// max speed of camera
	public float sensitivity = 0.25f; 		// keep it from 0..1
	public bool inverted = false;
	public float rotationSpeed = 100.0f;
	public float horizontalSpeed = 2.0f;
	private float baseSpeed = 50.0f;
	//private Vector3 lastMouse = new Vector3(0, 0, 0);
	private int speedDifficultyInterval = 20;
	private float speedIncrement = 15.0f;
	
	// smoothing
	public bool smooth = true;
	public float acceleration = 0.1f;
	private float actSpeed = 0.0f;			// keep it from 0 to 1
	private Vector3 lastDir = new Vector3();
	
	
	// Use this for initialization
	void Start () {
		speed = 50.0f;
	}
	

	void FixedUpdate () {

		if (((int)Time.timeSinceLevelLoad % speedDifficultyInterval == 0) && ((int)Time.timeSinceLevelLoad != 0)) {
			audio.Play ();
			speed = baseSpeed + ((int)Time.timeSinceLevelLoad / speedDifficultyInterval) * speedIncrement;

		}

		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		this.transform.Rotate(0, rotation, 0);

		float h = horizontalSpeed * Input.GetAxis("Mouse X");
		transform.Rotate(0, h, 0);
		Vector3 dir = new Vector3();			
		dir.z += 1.0f;

		dir.Normalize();
		
		
		if (dir != Vector3.zero) {
			// some movement 
			if (actSpeed < 1)
				actSpeed += acceleration * Time.deltaTime * 40;
			else 
				actSpeed = 1.0f;
			
			lastDir = dir;
		} else {
			// should stop
			if (actSpeed > 0)
				actSpeed -= acceleration * Time.deltaTime * 20;
			else 
				actSpeed = 0.0f;
		}
		if (smooth) 
			transform.Translate( lastDir * actSpeed * speed * Time.deltaTime );
			
		
		else 
			transform.Translate ( dir * speed * Time.deltaTime );
		
		
	}
	
	void OnGUI() {
		//GUILayout.Box ("actSpeed: " + actSpeed.ToString());
		//GUILayout.Box ("xRot: " + transform.eulerAngles.x);
	}
}
