using UnityEngine;
using System.Collections;

public class trackBehavior : MonoBehaviour {

	public genTrack hare;
	private int trackMovementOffsetDelay;

	// Use this for initialization
	void Start () {
		trackMovementOffsetDelay = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter () {
		trackMovementOffsetDelay--;
		if (trackMovementOffsetDelay < 0) {
			hare.moveTrack (hare.trackIndex);
			hare.incrementTrackIndex();
			trackMovementOffsetDelay = 0;
		}
	}
}
