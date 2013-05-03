using UnityEngine;
using System.Collections;

public class HitCounter : MonoBehaviour {
	
	int hits = 0;
	void RegisterHits() {
		hits ++;	
	}
	void OnGui() {
		GUI.Box(new Rect(10,10,100,20), hits.ToString());
	}

}
