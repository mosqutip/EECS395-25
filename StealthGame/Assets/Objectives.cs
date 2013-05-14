using UnityEngine;
using System.Collections;

public class Objectives : MonoBehaviour
{
	private string objectivesText;
	private bool showMenu = false;
	public Texture objectivesPane;
	
	void Start()
	{
		// Original height and width
		// Scale with gui matrix change
		objectivesText = "Use WASD or the arrow keys to move\n" +
					 	 "Hold tab to run\n" +
						 "Hold shift to sneak\n" +
					 	 "Avoid the guards and their flashlights\n" +
					 	 "To beat the level, find the flare and escape!";
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			showMenu = true;
		}
		if (Input.GetKeyUp(KeyCode.O))
		{
			showMenu = false;
		}
	}
	
	void OnGUI()
	{
		if (showMenu == true)
		{
			Rect objectivesPanePosition = new Rect(5.0f, 5.0f, 507.0f, 379.0f);
			// 5 pixel offset due to the label on top?
			Rect objectivesPosition = new Rect(10.0f, 5.0f, 497.0f, 369.0f);
			GUI.DrawTexture(objectivesPanePosition, objectivesPane);
			GUI.Label(objectivesPosition, objectivesText);
		}
	}
}