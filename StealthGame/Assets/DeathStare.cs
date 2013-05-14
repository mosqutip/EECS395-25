using UnityEngine;
using System.Collections;

public class DeathStare : MonoBehaviour
{
	public GameObject target;
	public GameObject roboKyle;
	public float fieldOfVision;
	public float minDetectDistance;
	public float maxDetectDistance;
	
	void Start ()
	{
	}
	
	void Update() 
	{
		if (CanSee(roboKyle, target))
		{
			Destroy(target);
		}
	}		
	
	void castGizmoRays(Vector3 pos, Vector3 dir)
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(pos, dir);
	}
		
	bool CanSee(GameObject guard, GameObject thing)
	{

		//test if hit is player
		//test if player falls into acceptable range
		
		Vector3 rayDirection = thing.transform.position - guard.transform.position;
		RaycastHit hit;
		float distanceToPlayer = Vector3.Distance(guard.transform.position, thing.transform.position);
		
		if(Physics.Raycast(guard.transform.position, rayDirection, out hit))
		{
			if((hit.transform.tag == "Player") && (distanceToPlayer <= minDetectDistance))
			{
	            return true;
	        }
			else
			{
        		return false;
			}
	    }
	    if ((Vector3.Angle(rayDirection, guard.transform.forward)) < fieldOfVision)
		{
	        if (Physics.Raycast (guard.transform.position, rayDirection, out hit))
			{
	            if (hit.transform.tag == "Player")
				{
	                return true;
	            }
				else
				{
        			return false;
				}
	        }
	    }
		return false;
	}
	
	void OnDrawGizmos()
	{
		castGizmoRays(roboKyle.transform.position, target.transform.position);
	}
}