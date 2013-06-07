using UnityEngine;
using System.Collections;

public class GuardStationary : MonoBehaviour {
	
	int speed = 3;
	Vector3 direction;
	// Use this for initialization
	void Start () {
			direction = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		if (! GetComponent<GuardHearing>().getAlerted())
		{
			var newRotation = Quaternion.LookRotation(direction, Vector3.up);
			newRotation.x = 0;
			newRotation.z = 0;
			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed *Time.deltaTime);
		}
	}
}
