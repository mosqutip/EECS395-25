using UnityEngine;
using System.Collections;

public class GuardHearing : MonoBehaviour
{
	public int speed;
	public bool active;
	
	void OnTriggerEnter(Collider obj)
	{
		if (obj.tag == "Noise")
		{
			active = true;
		}
	}
	
	void OnTriggerExit(Collider obj)
	{
		if (obj.tag == "Noise")
		{
			active = false;
		}
	}
	
	void OnTriggerStay(Collider obj)
	{
		if (obj.tag == "Noise")
		{
			Vector3 start = transform.position;
			Vector3 end = obj.transform.parent.gameObject.transform.position;
			RaycastHit hit;
			if (Physics.Raycast(start, end - start, out hit))
			{
				if (hit.collider.tag == "Player")
				{
					var newRotation = Quaternion.LookRotation(obj.transform.position - transform.position, Vector3.up); 
					newRotation.x = 0;
					newRotation.z = 0;
					transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed *Time.deltaTime);
				}
			}
		}
	}
}