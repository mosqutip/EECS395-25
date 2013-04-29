using UnityEngine;
using System.Collections;

public class OnTouchKillPlayer : MonoBehaviour {
	
	public GameObject target;
	
	void OnTriggerEnter() {
		Destroy(target);
		Application.Quit();
	}
	
}
