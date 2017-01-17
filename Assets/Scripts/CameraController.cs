using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour {

	private float h;
	private float v;
	private Vector3 cameraRotation;
	private GameObject player;
	private Vector3 playerPosition;
	private Vector3  cameraOffset;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		cameraRotation = transform.rotation.eulerAngles;
		cameraOffset = transform.position-player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		 h = CrossPlatformInputManager.GetAxis("CHorizontal");
    	 v = CrossPlatformInputManager.GetAxis("CVertical");
    	 cameraRotation.y += h ;
    	 cameraRotation.x -= v ;
		RotateCamera(cameraRotation);

		FollowPlayer();
	}

	private void RotateCamera(Vector3 rotateDirection){
		transform.rotation = Quaternion.Euler(rotateDirection);
	}

	private void FollowPlayer(){
		transform.position = player.transform.position + cameraOffset;
	} 
          



}
