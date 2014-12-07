using UnityEngine;
using System.Collections;

public class offTrack : MonoBehaviour {

	public screenFade fader;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter () {
		fader.EndScene();
	}
}
