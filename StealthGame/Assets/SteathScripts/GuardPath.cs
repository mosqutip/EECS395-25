using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]  
[RequireComponent(typeof(CharacterController))]
public class GuardPath : MonoBehaviour
{
 	//locomotion
	protected Animator animator;
    private float speed = 3;
    private float direction = 0;
    private Locomotion locomotion = null;
	
	//guard paths
	public Transform[] waypoints;
    public float waypointDistance = 0.25f;
	public bool loop = true;
	
	//index of the next waypoint	
    private int targetwaypoint;
 
    // Use this for initialization
    protected void Start ()
    {
		//locomotion is the animator script from Unity's starter-kit
		//the script "locomotion" is found under the locomotion folder..
		//locomotion.Do gives animated movement.
		animator = GetComponent<Animator>();
        locomotion = new Locomotion(animator);
		
        if(waypoints.Length<=0)
        {
            Debug.Log("No waypoints on "+name);
            enabled = false;
        }
		
        targetwaypoint = 0;
    }
	
    // moves us along current heading
    protected void Update()
    {	
		//select the correct waypoing
		if ((transform.position - waypoints[targetwaypoint].position).magnitude <= waypointDistance)
		{
			targetwaypoint ++;
			if(targetwaypoint >= waypoints.Length)
            {
                targetwaypoint = 0;
            }
		}
		//get the direction to that waypoint
		direction = Vector3.Angle(transform.position,waypoints[targetwaypoint].position);
		locomotion.Do(speed, direction);
	}

    // draws red line from waypoint to waypoint
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(waypoints==null)
		{
        	;
		}
        for(int i=0;i< waypoints.Length;i++)
        {
            Vector3 pos = waypoints[i].position;
            if(i>0)
            {
                Vector3 prev = waypoints[i-1].position;
                Gizmos.DrawLine(prev,pos);
            }
        }
    }
 
}