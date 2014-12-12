using UnityEngine;
using System.Collections;

public class genTrack : MonoBehaviour {

	public GameObject track;
	public Transform startPosition;
	private float heightOffset = -5f;
	public float widthOffset = 16f;
	public GameObject[] tracks;
	public int trackSegments = 15; // Length of moving track
	private Quaternion rotation;
	public int trackIndex = 0;
	private float angleThreshold; // Maximum turn angle
	public float pivotOffset = 25f;  //Distance from center of track to the pivot point of next track piece
	private float angleRange;
	private float angleIncreaseStart = 60f; //Time when track turns start getting sharper
	private float angleIncreaseStop = 120f;
	private float angleDifficulty = 15.0f;

	void Start () {
		angleThreshold = 15f;
		angleRange = 15f;
		transform.Translate (new Vector3 (startPosition.position.x + widthOffset, startPosition.position.y + heightOffset, startPosition.position.z));
		transform.localRotation = startPosition.localRotation;
		Instantiate (track,transform.position,transform.localRotation);
		rotation = startPosition.localRotation;

		for (int i = 0; i < trackSegments-2; i++) {
			layTrack();
		}
		tracks = GameObject.FindGameObjectsWithTag("Respawn");

	}

	IEnumerator trackGeneration() {
		for (int i = 0; i < 100; i++) {
			moveTrack(trackIndex);
			incrementTrackIndex ();
			yield return new WaitForSeconds(0.9f);
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			layTrack ();
		}
		if ((Time.timeSinceLevelLoad >= angleIncreaseStart) && (Time.timeSinceLevelLoad <= angleIncreaseStop)) {
			angleThreshold = Time.timeSinceLevelLoad / (angleIncreaseStop - angleIncreaseStart) * angleDifficulty;
			angleRange = angleThreshold;
		}
	}

	public void incrementTrackIndex() {
		trackIndex ++;
		if (trackIndex == trackSegments) {
			trackIndex = 0;
		}
		
	}

	public void moveTrack(int _trackIndex) {
		transform.Translate(0, 0, pivotOffset);
		float rndAngle =  Random.Range (-angleRange, angleRange);
		if (Mathf.Abs(rotation.eulerAngles.y + rndAngle) > angleThreshold) {
			rotation.eulerAngles = new Vector3(0,0,0);
		} else {
			rotation.eulerAngles = new Vector3(0,rndAngle + rotation.eulerAngles.y,0);
		}
		transform.Rotate(rotation.eulerAngles);
		tracks[_trackIndex].transform.position = this.transform.position;
		tracks[_trackIndex].transform.rotation = this.transform.localRotation;

	}

	public void layTrack() {   // Translate Y, Set rotation, Instantiate next track section
		transform.Translate(0, 0, pivotOffset);
		float rndAngle =  Random.Range (-angleRange, angleRange);
		if (Mathf.Abs(rotation.eulerAngles.y + rndAngle) > angleThreshold) {
			rotation.eulerAngles = new Vector3(0,0,0);
		} else {
			rotation.eulerAngles = new Vector3(0,rndAngle + rotation.eulerAngles.y,0);
		}
		transform.Rotate(rotation.eulerAngles);
		Instantiate (track,this.transform.position,this.transform.localRotation);
	}

	public Vector3 getTrackPosition (int segmentIndex) {
		return tracks[segmentIndex].transform.position;
	}

	void OnGUI() {
		GUILayout.Box ("Time: " + (int)Time.timeSinceLevelLoad);
		//GUILayout.Box ("AngleThreshold: " + angleThreshold);
	}
}
