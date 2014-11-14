using UnityEngine;
using System.Collections;

public class driveCam : MonoBehaviour {

	public Rigidbody vessel;
	public GameObject tree;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion rotation = Quaternion.identity;
		if (Input.GetKey (KeyCode.JoystickButton0)) {
			Instantiate (tree, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), rotation);
		}
		//vessel.AddForce(new Vector3(50f,0f,0f)*Input.GetAxis ("Horizontal"));
		//vessel.AddTorque (new Vector3(0f,20f,0f) * Input.GetAxis ("Horizontal"));
	}
}
