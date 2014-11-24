using UnityEngine;
using System.Collections;

public class racerBehavior : MonoBehaviour {

	public genTrack hare;
	public GameObject player;
	private int targetPiece = 1;
	private float targetingThreshold = 10f;
	public float racerSpeed = 2.5f;
	private float rubberBand;
	private float racerVariance;
	public float boost = 0.1f;

	// Use this for initialization
	void Start () {
		racerVariance = Random.Range (0.95f, 1.05f);
	}
	
	// Update is called once per frame
	void Update () {
		rubberBand = Vector3.Distance(hare.transform.position, this.transform.position) / Vector3.Distance(hare.transform.position, player.transform.position);	
		float theSpeed = (Time.deltaTime+racerSpeed) * racerVariance * (rubberBand + boost);
		transform.position = Vector3.Slerp (transform.position, new Vector3(hare.getTrackPosition(targetPiece).x, hare.getTrackPosition(targetPiece).y, hare.getTrackPosition(targetPiece).z), theSpeed );
		transform.LookAt (hare.getTrackPosition(targetPiece));
		if (Vector3.Distance (transform.position, new Vector3(hare.getTrackPosition(targetPiece).x, hare.getTrackPosition(targetPiece).y, hare.getTrackPosition(targetPiece).z)) < targetingThreshold) {
			targetPiece++;
			if (targetPiece == hare.trackSegments) {
				targetPiece = 0;
			}
		}
	}

	void OnGUI() {
		GUILayout.Box ("deltaAB: " + Vector3.Distance(hare.transform.position, this.transform.position));
		GUILayout.Box ("deltaCB: " + Vector3.Distance(hare.transform.position, player.transform.position));
		GUILayout.Box ("Rubberband: " + rubberBand);
		GUILayout.Box ("Racer Speed: " + (Time.deltaTime+racerSpeed) * racerVariance * (rubberBand+boost));
	}
}
