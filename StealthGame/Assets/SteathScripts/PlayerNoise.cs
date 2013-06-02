using UnityEngine;
using System.Collections;

public class PlayerNoise : MonoBehaviour
{
	private PlayerMovement move;
	
	public SphereCollider noiseSphere;	
	public float sprintRadius=5f, walkRadius=2.5f, sneakRadius=1.25f, stillRadius=0.1f;

	void Start ()
	{
		move = GetComponent<PlayerMovement>();
	}
	
	void Update ()
	{
		noiseSphere.radius = MovementStateToRadius(move);
	}
	
	private float MovementStateToRadius(PlayerMovement move)
	{
		if (move.speed < 0.5)
		{
			return stillRadius;
		}
		if (move.sprint)
		{
			return sprintRadius;
		}
		if (move.sneak)
		{
			return sneakRadius;
		}
		else
		{
			return walkRadius;
		}
	}
	
	public void setRadius(float factor)
	{
		sprintRadius *= factor;
		walkRadius *= factor;
	}
}
