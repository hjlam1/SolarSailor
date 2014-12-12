using UnityEngine;
using System.Collections;

public class racerBehavior : MonoBehaviour {

	public genTrack hare;
	public GameObject player;
	public flyCam playerCam;
	private int targetPiece = 1;
	private float targetingThreshold = 50f;
	private float targetVariance;
	public float racerSpeed = 2.5f;
	private float rubberBand;
	private float racerVariance;
	public float boost;
	private float zHeightOffset = 8f;

	// Use this for initialization
	void Start () {
		racerVariance = Random.Range (0.95f, 1.05f);
		targetVariance = Random.Range (-1f, 1f);
		//boost = 0.1f*Mathf.Sin (Time.timeSinceLevelLoad);
	}
	

	void FixedUpdate () {
		rubberBand = Vector3.Distance(hare.transform.position, this.transform.position) / Vector3.Distance(hare.transform.position, player.transform.position);	
		//float theSpeed = (Time.deltaTime) * racerVariance * (rubberBand + boost);
		float theSpeed = racerVariance * (rubberBand + (Mathf.Sin (Time.timeSinceLevelLoad) * boost));
		//transform.position = Vector3.Slerp (transform.position, new Vector3(hare.getTrackPosition(targetPiece).x + targetVariance, hare.getTrackPosition(targetPiece).y, hare.getTrackPosition(targetPiece).z), theSpeed );
		//rigidbody.AddRelativeForce(Vector3.forward * theSpeed * 200f);
		Vector3 thePlace = new Vector3(hare.getTrackPosition(targetPiece).x + targetVariance, hare.getTrackPosition(targetPiece).y + zHeightOffset, hare.getTrackPosition(targetPiece).z);
		Vector3 inBetween = Vector3.Slerp (new Vector3(transform.position.x, transform.position.y, transform.position.z+0.75f), thePlace, Time.deltaTime);
		transform.LookAt (inBetween);

		Debug.Log ("theSpeed: " + theSpeed);
		Debug.Log ("RB: " + rubberBand);
		Vector3 movement = new Vector3();
		movement.z = playerCam.speed / 50 * theSpeed * rubberBand;
		transform.Translate (movement);
		if (Vector3.Distance (transform.position, thePlace) < targetingThreshold) {
			targetPiece++;
			//targetVariance = Random.Range (-20f, 20f);
			if (targetPiece == hare.trackSegments) {
				targetPiece = 0;
			}
		}
	}

	void OnGUI() {
		//GUILayout.Box ("deltaAB: " + Vector3.Distance(hare.transform.position, this.transform.position));
		//GUILayout.Box ("deltaCB: " + Vector3.Distance(hare.transform.position, player.transform.position));
		//GUILayout.Box ("Rubberband: " + rubberBand);
		//GUILayout.Box ("Racer Speed: " + (Time.deltaTime+racerSpeed) * racerVariance * (rubberBand+boost));
	}
}
