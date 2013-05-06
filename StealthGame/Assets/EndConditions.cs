using UnityEngine;
using System.Collections;
using System;

public class EndConditions : MonoBehaviour {
	
    void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "door_4_1")
		{
			int nextLevel = Application.loadedLevel + 1;
			Destroy(GameObject.Find("CurrentLevel"));
			Application.LoadLevel(nextLevel);
		}
	}
}