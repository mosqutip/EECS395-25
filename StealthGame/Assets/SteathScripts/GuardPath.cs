using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]  
[RequireComponent(typeof(CharacterController))]
public class GuardPath : MonoBehaviour
{
 	//locomotion
	protected Animator animator;
	protected CharacterController controller;
    private Locomotion locomotion = null;
	
	//guard paths
	public float speed = 3f;
	public int rotationSpeed = 3;
	public Transform[] waypoints;
    public float waypointDistance = 25f;
	public bool loop = true;
	
	
	//index of the next waypoint	
    private int targetWaypoint;
	
	private float currentDistance()
	{
		return Vector3.Distance(transform.position,waypoints[targetWaypoint].position);
	}
	
	private Transform currentTarget()
	{
		return waypoints[targetWaypoint];
	}
	
    // Use this for initialization
    protected void Start ()
    {
		//locomotion is the animator script from Unity's starter-kit
		//the script "locomotion" is found under the locomotion folder..
		//locomotion.Do gives animated movement.
		animator = GetComponent<Animator>();
        locomotion = new Locomotion(animator);
		//access the attached CharCtrlr.
		controller = GetComponent<CharacterController>();
		
        if(waypoints.Length<=0)
        {
            Debug.Log("No waypoints on "+name);
            enabled = false;
        }
		
        targetWaypoint = 0;
    }
	
    // moves us along current heading
    protected void Update()
    {	
		//select the correct waypoint
		if (currentDistance() <= waypointDistance)
		{
			targetWaypoint = (targetWaypoint + 1)%waypoints.Length;
		}
		Vector3 direction = Quaternion.LookRotation(waypoints[targetWaypoint].transform.position - transform.position).eulerAngles;
        //make the robot stop shoe-gazing
		direction.x = 0;
        direction.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(direction), Time.deltaTime*rotationSpeed);
		//0f: make the robot walk straight
		locomotion.Do(speed, 0f);
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