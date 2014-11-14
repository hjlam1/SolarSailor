using UnityEngine;
using System.Collections;

public class genTrack : MonoBehaviour {

	public GameObject track;
	public Transform startPosition;
	private GameObject leadTrack;
	private int numOfTracks = 5;
	private Quaternion rotation;
	public float heightOffset = -2f;
	public float widthOffset = 16f;

	// Use this for initialization
	void Start () {

		transform.Translate (new Vector3 (startPosition.position.x + widthOffset, startPosition.position.y + heightOffset, startPosition.position.z));
		transform.localRotation = startPosition.localRotation;
		Instantiate (track,transform.position,transform.localRotation);
		rotation = startPosition.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		// If (number of track pieces ahead)

		if (Input.GetKeyDown(KeyCode.Space)) {
			//		Translate Y 
			//		Set rotation
			//		Instantiate next track section

			transform.Translate(0, 0, 45f);
			float rndAngle =  Random.Range (-20f, 20f);
			if (Mathf.Abs(rotation.eulerAngles.y) + rndAngle > 45f) {
				rotation.eulerAngles = new Vector3(0,0,0);
			} else {
				rotation.eulerAngles = new Vector3(0,rndAngle + rotation.eulerAngles.y,0);
			}
			transform.Rotate(rotation.eulerAngles);
			Instantiate (track,this.transform.position,this.transform.localRotation);

		
		}
	}
}
