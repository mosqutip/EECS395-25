using UnityEngine;
using System.Collections;

public class GuardHearing : MonoBehaviour {
	
	public int speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay (Collider obj){
		if (obj.tag != "env")
		{
			Debug.Log("incir");
			var newRotation = Quaternion.LookRotation(obj.transform.position - transform.parent.transform.position, Vector3.up); 
			newRotation.x = 0;
			newRotation.z = 0;
			transform.parent.transform.rotation = Quaternion.Slerp(transform.parent.transform.rotation, newRotation, speed *Time.deltaTime);
			//this.transform.parent.transform.LookAt(obj.transform.position, this.transform.up);// Rotate(this.transform.u, 90);
		}
	}
}
