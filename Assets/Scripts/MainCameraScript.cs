using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {

	private Camera mainCam;
	private AudioSource aso;
	private RaycastHit hit;
	private Ray ray;
	private bool pause;

	// Use this for initialization
	void Awake() {
		this.mainCam = Camera.main;
		this.aso = GetComponent<AudioSource>();
		this.pause = false;
	}
	
	// Update is called once per frame
	public void shooting() {
		this.ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		if (!pause && Physics.Raycast(ray, out hit)) {
			this.aso.Play();
			Debug.DrawLine(ray.origin, hit.point, Color.red);

			if (hit.transform.tag == "anemy") {
				hit.transform.GetComponent<AnemySkeletonScript>().hit();

			} else if (hit.transform.tag == "boss") {
				hit.transform.GetComponent<AnemyBossScript>().hit();

			} else if (hit.transform.tag == "start") {
				hit.transform.GetComponent<GameStartScript>().gameStart();

			}
		}
	}

	public void setSootingPause(bool b) {
		this.pause = b;
	}
}
