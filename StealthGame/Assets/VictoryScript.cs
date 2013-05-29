using UnityEngine;
using System.Collections;

public class VictoryScript : MonoBehaviour
{
	
	public Texture vicPic;
	
	void OnGUI()
	{
		
		GUI.DrawTexture(new Rect(Screen.width/2 - 160, 160, 320, 320), vicPic);
		transform.Translate(0, 0, 0);
		if (GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2 - 15, 100, 30), "Play Again"))
		{
			Application.LoadLevel("Escape");
		}
	}
}
