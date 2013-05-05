using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		transform.Translate(0, 0, 0);
		if (GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2 - 15, 100, 30), "Retry")) {
			Application.LoadLevel(GameObject.Find("CurrentLevel").GetComponent<CurrentLevel>().current);
		}
	}
}
