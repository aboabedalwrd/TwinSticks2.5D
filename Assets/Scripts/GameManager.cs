using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public bool isRecording;
	public bool playBackIsOver;
	public GameObject secondCamera; 

	void Start () {
		playBackIsOver = false;
		isRecording = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CrossPlatformInputManager.GetButton ("Fire1") && !playBackIsOver) {
			secondCamera.GetComponent<RawImage>().enabled = true;
			isRecording = false;
		} else {
			secondCamera.GetComponent<RawImage>().enabled = false;
			isRecording = true;
		}
	}
}
