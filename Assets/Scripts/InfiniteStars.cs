using UnityEngine;
using System.Collections;

public class InfiniteStars : MonoBehaviour {

	public int starsMax = 100;
	public float starSize = 1.0f;
	public float starDistance = 10f;
	public float starClipDistance = 5f;


	private Transform tx;
	private ParticleSystem.Particle[] points;
	private float starDistanceSqr;
	private float starClipDistanceSqr;


	// Use this for initialization
	void Start () {
		tx = transform;
		starDistanceSqr = starDistance * starDistance;
		starClipDistanceSqr = starClipDistance * starClipDistance;
	}

	private void  CreateStars() {
		points = new ParticleSystem.Particle[starsMax];
		for (int i = 0; i<starsMax; i++) {
			points[i].position = Random.insideUnitSphere.normalized * starDistance + tx.position;
			points[i].color = new Color(1,1,1,1);
			points[i].size = starSize;
		}
	}

	// Update is called once per frame
	void Update () {
		if (points==null) CreateStars();
		for (int i=0; i<starsMax; i++) {
			if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr) {
				points[i].position = Random.insideUnitSphere * starDistance + tx.position;
			}
			if ((points[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr) {
				float percentAlpha = (points[i].position - tx.position).sqrMagnitude/ starClipDistanceSqr;
				points[i].color = new Color(1,1,1, percentAlpha);
				points[i].size = percentAlpha * starSize;
			}
		}


		particleSystem.SetParticles (points, points.Length);
	}
}
