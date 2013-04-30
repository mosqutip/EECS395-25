using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerStay (Collider obj) {
		if (obj.tag != "env")
		{	
			Vector3 start = this.transform.parent.gameObject.transform.position;
			Vector3 end = obj.transform.position;
			RaycastHit hit;
			if (Physics.Raycast(start, end - start, out hit))
			{
				if (hit.collider.tag != "env")
				{
					Debug.Log("hit");
				}
				
		}
		}
			
			
	}
}

