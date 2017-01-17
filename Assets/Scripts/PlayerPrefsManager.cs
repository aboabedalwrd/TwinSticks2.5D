﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume)
	{
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume's  out of range");
		}

	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {

			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(),1);// USE 1 FOR TRUE.

		} else {
			Debug.LogError("Trying to unlock a level higher than the build order");
		}	
	}

	public static void LockLevel (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {

			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(),0);// USE 0 FOR False.

		} 
	}


	public static bool IsLevelUnlocked(int level){

		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			return isLevelUnlocked;


		} else {
			return false;	
		}
	}

	public static void SetDifficulty (float difficulty)
	{
		if (difficulty >= 0f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		}
		

	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}

}
