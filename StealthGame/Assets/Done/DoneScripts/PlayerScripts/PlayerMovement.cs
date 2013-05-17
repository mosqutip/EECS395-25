using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{	
	private Animator anim;				// Reference to the animator component.
	private HashIDs hash;			// Reference to the HashIDs.
	public float turnSmoothing = 15f;	// A smoothing value for turning the player.
	public float speedDampTime = 0.1f;	// The damping for the speed parameter
	public float speed;
	public bool sneak;
	public bool sprint;
	public int cheatMode;
	
	void Awake()
	{
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
	}
	
	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		sneak = Input.GetButton("Sneak");
		sprint = Input.GetButton("Sprint");
		Move(h, v, sneak, sprint);
	}
	
	void Update()
	{
		AudioManagement();
	}
	
	void Move(float horizontal, float vertical, bool sneaking, bool sprinting)
	{
		anim.SetBool(hash.sneakingBool, sneaking);
		anim.SetBool(hash.sprintingBool, sprinting);
	
		if (horizontal != 0f || vertical != 0f)
		{
			Rotating(horizontal, vertical);
			
			if (sprinting && (GameObject.Find("Stamina").GetComponent<Stamina>().stamina > 0))
			{
				speed = 10f*cheatMode;
			}
			else
			{
				speed = 2f*cheatMode;
			}
			anim.SetFloat(hash.speedFloat, speed, speedDampTime, Time.deltaTime);	
		}
		else
		{
			speed = 0;
			anim.SetFloat(hash.speedFloat, speed);
		}
	}
	
	
	void Rotating(float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		transform.rotation = newRotation;
	}
	
	void AudioManagement()
	{
		// If the player is currently in the run state...
		if (anim.GetCurrentAnimatorStateInfo(0).nameHash == hash.locomotionState)
		{
			if (!audio.isPlaying)
			{
				audio.Play();
	
			}
		}
		else
		{
			// Otherwise stop the footsteps.
			audio.Stop();
		}
	}
}
