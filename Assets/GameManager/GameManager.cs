using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool isRecording;
	public bool playBackIsOver;
	void Start () {
		playBackIsOver = false;
		isRecording = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CrossPlatformInputManager.GetButton ("Fire1") && !playBackIsOver) {
			isRecording = false;
		} else {
			isRecording = true;
		}
	}
}
