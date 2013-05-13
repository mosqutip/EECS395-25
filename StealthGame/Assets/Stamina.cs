using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour
{
	Vector3 scale;
	private int xSize = Screen.width, ySize = Screen.height;
	private float xOffset = (Screen.width * 0.25f), yOffset = (Screen.height * 0.05f),
						    screenScaleX = (Screen.width / 1024.0f), screenScaleY = (Screen.height / 768.0f);
	public float stamina;
	public Texture emptyBar, fullBar;
	public float speed;
	public float rechargeSpeed;
	private Rect emptyBarRect;

	void Start ()
	{
		emptyBarRect = new Rect((xSize - xOffset - 5.0f), (ySize - yOffset - 5.0f), xOffset, yOffset);
		scale = transform.localScale;
	}
	
	void Update ()
	{
		PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		
		if (playerMovement.sprint && !playerMovement.sneak && playerMovement.speed > 0)
		{
			if (stamina > 0)
			{
				stamina -= (Time.deltaTime * speed * (1f / 10f));
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
				stamina += (Time.deltaTime * rechargeSpeed * (1f/10f)); 
			}
		}
	}
	
	void OnGUI ()
	{
		Rect fullBarRect = new Rect(emptyBarRect.x + (5.0f * screenScaleX), emptyBarRect.y + (5.0f * screenScaleY),
									stamina * (xOffset - (10.0f * screenScaleX)), (yOffset - (10.0f * screenScaleY)));
		GUI.DrawTexture(emptyBarRect, emptyBar);
		GUI.DrawTexture(fullBarRect, fullBar);
	}
}
