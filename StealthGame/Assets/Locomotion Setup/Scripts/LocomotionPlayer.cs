 /// <summary>
/// 
/// </summary>

using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]  

public class LocomotionPlayer : MonoBehaviour {

    protected Animator animator;

    private float speed = 0;
    private float direction = 0;
    private Locomotion locomotion = null;

	void Start () 
	{
        animator = GetComponent<Animator>();
        locomotion = new Locomotion(animator);
	}
    
	void Update ()
	{
        if (animator && Camera.main)
		{
            JoystickToEvents.Do(transform,Camera.main.transform, ref speed, ref direction);
            
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
				locomotion.Do(speed * 8, direction * 180);
			}
			else {
				locomotion.Do(speed, direction * 180);
			}
		}		
	}
}
