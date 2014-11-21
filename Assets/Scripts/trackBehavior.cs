using UnityEngine;
using System.Collections;

public class trackBehavior : MonoBehaviour {

	public Transform startPosition;
	public float heightOffset = -1f;
	public float widthOffset = 16f;
	public GameObject section;
	public GameObject[] track;
	public int trackPieces;

	private Quaternion rotation;

	// Use this for initialization
	void Start () {
		track = new GameObject[trackPieces];

		transform.Translate (new Vector3 (startPosition.position.x + widthOffset, startPosition.position.y + heightOffset, startPosition.position.z));
		transform.localRotation = startPosition.localRotation;
		track[0] = Instantiate (section, transform.position, transform.localRotation) as GameObject;
		rotation = startPosition.localRotation;

		for (int i = 1; i < trackPieces; i++) {
			//track[i] = Instantiate 
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter () {
		//rabbit.layTrack();

	}
}
