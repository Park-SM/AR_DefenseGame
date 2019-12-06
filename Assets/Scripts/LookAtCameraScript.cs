using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraScript : MonoBehaviour {

	private Transform myTrans;
	private Transform camTrans;

	// Use this for initialization
	void Awake () {
		this.myTrans = GetComponent<Transform>();
		this.camTrans = Camera.main.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		myTrans.LookAt(camTrans);
	}
}
