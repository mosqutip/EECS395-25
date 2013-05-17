using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour
{	
	private float clock;
	private Animator anim;
	private PlayerMovement move;
	private HashIDs hash;
	private bool playerDead;
	public float delay = 2.5f;
	
	void Awake()
    {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        move = player.GetComponent<PlayerMovement>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
    }
	
	void OnTriggerEnter (Collider obj)
	{
		
		if (obj.tag == "Player")
		{	
			Vector3 start = this.transform.parent.gameObject.transform.position;
			Vector3 end = obj.transform.position;
			RaycastHit hit;
			if (Physics.Raycast(start, end - start, out hit))
			{
				if (hit.collider.tag == "Player")
				{
					if (!playerDead)
					{
	                	PlayerDying();
					}
				}
			}
		}
	}   
    
    void Update()
    {
	    if (playerDead)
        {
            PlayerDead();
            LevelReset();
        }
    }
    
    void PlayerDying()
    {
        playerDead = true;
        anim.SetBool(hash.deadBool, playerDead);
    }
    
    void PlayerDead()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).nameHash == hash.dyingState)
		{
            anim.SetBool(hash.deadBool, false);
		}
        move.enabled = false;
    }
    
    
    void LevelReset()
    {
        clock += Time.deltaTime;
        if (clock >= delay)
		{
            Application.LoadLevel("Gameover");
		}
    }
}