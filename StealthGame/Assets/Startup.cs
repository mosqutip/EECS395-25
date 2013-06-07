using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {
	void OnGUI () {
		GUI.Label(new Rect(Screen.width/2-50,10,200,200), "Hold 'o' for directions.");
	}
}
