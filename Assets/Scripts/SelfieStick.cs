using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour {

	private float h;
	private float v;
	private GameObject player;
	private Vector3 armRotation;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		armRotation =transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
	   	 h = CrossPlatformInputManager.GetAxis("CHorizontal");
    	 v = CrossPlatformInputManager.GetAxis("CVertical");
    	 armRotation.y -= h;
		 armRotation.z += v;
		 FollowPlayer();
		RotateStick(armRotation);
	}

	private void FollowPlayer(){

		transform.position = player.transform.position;
	}

	private void RotateStick(Vector3 rotateDirection){
		transform.rotation = Quaternion.Euler(rotateDirection);
	}

}
