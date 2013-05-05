using UnityEngine;
using System.Collections;
using System;

public class EndConditions : MonoBehaviour {
	
    void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "door_4_1")
		{
			int nextLevel = Application.loadedLevel + 1;
//			int counter = Convert.ToInt32(nextLevel.Substring((nextLevel.Length - 1), 1));
//			nextLevel = nextLevel.Substring (0, (nextLevel.Length - 1));
//			nextLevel += counter;
//			Debug.Log(nextLevel);
			Application.LoadLevel(nextLevel);
		}
	}
}