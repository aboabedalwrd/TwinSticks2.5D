using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour {


	private List<MyKeyFrame> keyFrames = new List<MyKeyFrame>(); 
	private GameManager gameManager;
	private int replayFrame = 0;
	private int recordFrame = 0;
	private Rigidbody rigidBody;

	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
		rigidBody = GetComponent<Rigidbody>();
	}

	
	void Update ()
	{
		if (gameManager.isRecording) {
			Record ();
		} else {
			PlayBack();
		}
		  

	}

	void Record ()
	{	
		if (rigidBody) {
			rigidBody.isKinematic = false;
		}

		float time = Time.time;
		print("Recording Frame " + recordFrame); 

		keyFrames.Add( new MyKeyFrame(time, transform.position, transform.rotation));
		recordFrame++;
	}

	void PlayBack ()
	{

		if (rigidBody) {
			rigidBody.isKinematic = true;
		}

		if (replayFrame < recordFrame) {
			print ("PlayBack Frame " + replayFrame); 
			transform.position = keyFrames [replayFrame].position;
			transform.rotation = keyFrames [replayFrame].rotation;
			replayFrame++;
		} else {
			print("PlayBack is Over");
		}

	}
}

/// <summary>
/// A structure for storing time, rotation and position; 
/// </summary>
public struct MyKeyFrame {

		public float frameTime;
		public Vector3 position;
		public Quaternion rotation;

		public MyKeyFrame (float aTime , Vector3 aPosition, Quaternion aRotation){
			frameTime = aTime;
			position = aPosition;
			rotation = aRotation;
		}
}


