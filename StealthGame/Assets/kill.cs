using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour {
	
	private bool isHit = false;
	
	void OnGUI() {
		if (isHit) {
			GUI.Label(new Rect(10,10,150,20),"You've been seen!");
		}
	}
	
	void OnTriggerEnter (Collider obj) {
		if (obj.tag != "env")
		{	
			Vector3 start = this.transform.parent.gameObject.transform.position;
			Vector3 end = obj.transform.position;
			RaycastHit hit;
			if (Physics.Raycast(start, end - start, out hit))
			{
				if (hit.collider.tag != "env")
				{
					isHit = true;
					Debug.Log("hit");
				}
			}
		}
	}
	
}

