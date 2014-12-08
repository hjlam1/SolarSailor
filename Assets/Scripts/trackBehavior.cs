using UnityEngine;
using System.Collections;

public class trackBehavior : MonoBehaviour {

	public genTrack hare;
	private int trackMovementOffsetDelay;
	public screenFade fader;

	// Use this for initialization
	void Start () {
		trackMovementOffsetDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Finish")) {
			fader.EndScene ();
		}

		trackMovementOffsetDelay--;
		if (trackMovementOffsetDelay < 0) {
			hare.moveTrack (hare.trackIndex);
			hare.incrementTrackIndex();
			trackMovementOffsetDelay = 0;
		}

	}
}
