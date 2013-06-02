using UnityEngine;
using System.Collections;

public class VictoryScript : MonoBehaviour
{
	private GUIStyle victoryStyle;
	
	void Start () {
		victoryStyle = new GUIStyle();
		victoryStyle.fontSize = 30;
	}
	
	void OnGUI()
	{
		
		GUI.Label(new Rect (Screen.width/2 - 65, Screen.height/4 - 15, 100, 30), "VICTORY!", victoryStyle);
		if (GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2 - 15, 100, 30), "Play Again"))
		{
			Application.LoadLevel("Escape");
		}
	}
}
