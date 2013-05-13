using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour {
	Vector3 scale; 
	public float stamina;
	public Texture emptyBar, fullBar;
	public float speed;
	public float rechargeSpeed;
	private Rect emptyBarRect = new Rect(Screen.width - 350, Screen.height - 60, 300, 50);

	void Start () {
		scale = transform.localScale;
	}
	
	void Update () {
		PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		
		if (playerMovement.sprint && !playerMovement.sneak && playerMovement.speed > 0)
		{
			if (stamina > 0)
			{
				stamina -= Time.deltaTime * speed * (1f/10f);
				if (stamina < 0)
				{
					stamina = 0;
				}
			}
		}
		else
		{
			if (stamina > 1)
			{
				stamina = 1;
			}
			if (stamina < 1)
			{
				stamina += Time.deltaTime * rechargeSpeed * (1f/10f); 
			}
		}
	}
	
	void OnGUI ()
	{
		Rect fullBarRect = new Rect(Screen.width - 340, Screen.height - 50, 280 * stamina, 30);
		GUI.DrawTexture(emptyBarRect, emptyBar);
		GUI.DrawTexture(fullBarRect, fullBar);
	}
}
