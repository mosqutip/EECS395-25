using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour
{	
	private float clock;
	private Animator anim;
	private PlayerMovement move;
	private HashIDs hash;
	private float detectionRate = 1.0f;
	
	public bool playerDead = false;
	public float delay = 2.5f;
	
	private bool playerInView = false;
	private LineRenderer killLine;
	
	void Awake()
    {
		killLine = gameObject.AddComponent<LineRenderer>();
		killLine.enabled = false;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        move = player.GetComponent<PlayerMovement>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
    }
	
	void OnTriggerEnter(Collider obj)
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
					playerInView = true;
				}
			}
		}
	}
	
	void PlayerInView()
	{
		Component deathLight = this.transform.parent.gameObject.GetComponentInChildren(typeof(Light));
		deathLight.light.spotAngle -= detectionRate;
		deathLight.light.color = new Color(1.0f, deathLight.light.color.g - 0.015625f, deathLight.light.color.b - 0.015625f, 1.0f);
		if (deathLight.light.spotAngle <= 5.0f)
		{
			killLine.enabled = true;
			deathLight.light.spotAngle = 5.0f;
			deathLight.light.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
			killLine.SetVertexCount(2);
			killLine.SetWidth(0.05f, 0.05f);
			killLine.material = new Material(Shader.Find("Particles/Additive"));
			Color start = new Color(1.0f, 0.0f, 0.0f, 1.0f);
			killLine.SetColors(start, start);
			if (!playerDead)
			{
				PlayerDying();
				audio.Play();
			}
		}
	}
	
	void ResetVisionCone()
	{
		Component deathLight = this.transform.parent.gameObject.GetComponentInChildren(typeof(Light));
		deathLight.light.spotAngle += 1.0f;
		deathLight.light.color = new Color(1.0f, deathLight.light.color.g + 0.015625f, deathLight.light.color.b + 0.015625f, 1.0f);
		if (deathLight.light.spotAngle > 63.0f)
		{
			deathLight.light.spotAngle = 63.0f;
			deathLight.light.color = new Color(1.0f, 1.0f, 1.0f, 100.0f);
		}
	}
	
	void OnTriggerExit(Collider obj)
	{
        if (obj.tag == "Player")
		{
			if (playerInView == true)
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerNoise>().setRadius(1.25f);
				GameObject.Find("AlarmLevel").GetComponentInChildren<Alarm>().setAlarmLevel();
				detectionRate += 0.5f;
				GameObject[] guards = GameObject.FindGameObjectsWithTag("Enemy");
				foreach (GameObject g in guards)
				{
					GuardPath temp = g.GetComponent<GuardPath>();
					if (temp != null)
					{
						temp.setWalkSpeed(1.25f);
						temp.setRotationSpeed(1.25f);
					}
					g.GetComponent<GuardHearing>().setTurnSpeed(1.25f);
				}
			}
			playerInView = false;
		}
    }
    
    void Update()
	{
		Vector3 pos1, pos2;
		pos1 = this.transform.parent.gameObject.transform.position;
		pos2 = GameObject.FindGameObjectWithTag("Player").transform.position;
		foreach (Transform child in GameObject.FindGameObjectWithTag("Player").transform)
		{
			if (child.name == "Hips")
			{
				pos2 = child.transform.position;
				break;
			}
		}
		pos1.y += 1.6f;
		killLine.SetPosition(0, pos1);
		killLine.SetPosition(1, pos2);
	    if (playerDead)
        {
            PlayerDead();
            LevelReset();
        }
		// Must follow the above block for death checking or an infinite death loop occurs.
		if (playerInView)
		{
			PlayerInView();
		}
		else
		{
			ResetVisionCone();
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