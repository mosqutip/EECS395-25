using UnityEngine;
using System.Collections;

public class GuardHearing : MonoBehaviour
{
	public int speed;

	void Start ()
	{
	}
	
	void Update ()
	{
	}
	
	void OnTriggerStay(Collider obj)
	{
		if (obj.tag == "Noise")
		{
			var newRotation = Quaternion.LookRotation(obj.transform.position - transform.parent.transform.position, Vector3.up); 
			newRotation.x = 0;
			newRotation.z = 0;
			transform.parent.transform.rotation = Quaternion.Slerp(transform.parent.transform.rotation, newRotation, speed *Time.deltaTime);
		}
	}
}
