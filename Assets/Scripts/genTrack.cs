using UnityEngine;
using System.Collections;

public class genTrack : MonoBehaviour {

	public GameObject track;
	public Transform startPosition;
	private Quaternion rotation;
	public float heightOffset = -1f;
	public float widthOffset = 16f;

	void Start () {

		transform.Translate (new Vector3 (startPosition.position.x + widthOffset, startPosition.position.y + heightOffset, startPosition.position.z));
		transform.localRotation = startPosition.localRotation;
		Instantiate (track,transform.position,transform.localRotation);
		rotation = startPosition.localRotation;
		StartCoroutine(trackGeneration ());
	}
	
	IEnumerator trackGeneration() {
		for (int i = 0; i < 60; i++) {
			layTrack();
			yield return new WaitForSeconds(0.8f);
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			layTrack ();
		}
	}

	public void layTrack() {   // Translate Y, Set rotation, Instantiate next track section
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
