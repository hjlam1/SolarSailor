using UnityEngine;
using System.Collections;

public class trackBehavior : MonoBehaviour {

	public genTrack hare;
	private int trackMovementOffsetDelay;
	public screenFade fader;
	public AudioSource rumble;


	// Use this for initialization
	void Start () {
		trackMovementOffsetDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit (Collider other) {

		if (other.tag == "Center") {
			if (!rumble.isPlaying) {
				//rumble.Play ();
			}
		}
	}


	void OnTriggerEnter (Collider other) {
		//Debug.Log (other.tag);
		if (other.CompareTag ("Finish")) {
			fader.EndScene ();
		}
		if ((other.tag == "Center")) {
			if (other.tag == "Center") {
				//rumble.Stop ();
			}
			trackMovementOffsetDelay--;
			if (trackMovementOffsetDelay < 0) {
				hare.moveTrack (hare.trackIndex);
				hare.incrementTrackIndex();
				trackMovementOffsetDelay = 0;
			}
		}

	}
}
