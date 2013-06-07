using UnityEngine;
using System.Collections;

public class Objectives : MonoBehaviour
{
	private bool showMenu = false;
	public Texture objectivesPane;
	public string objectivesText;
	
	void Start()
	{
		
		
	/*	"Use WASD or the arrow keys to move\n" +
	 	"Hold space to run. Running will make you louder.\n" +
				"Sprinting takes stamina (the green bar on the bottom-right)."+
		"Hold shift to sneak. Sneaking will make you quieter.\n" +
				"Avoid the guards and their flashlights.\n" +
		"If a guard can see you, it will swiftly kill you with lasers\n"+
				"(You'll have a brief window of opportunity to escape)."+
				"The more close calls you have, the more alert the guards will be."+
				"The alert level is in the bottom-left corner."+
		"Press Q and E to rotate the camera orientation.\n"+
		"The purple line on your minimap points to your next objective at all times.\n"+
				"This game is hard; stop complaining."*/

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
			GUI.color = new Color(GUI.color.a, GUI.color.g, GUI.color.b, 0.75f);
			GUI.DrawTexture(objectivesPanePosition, objectivesPane);
			GUI.Label(objectivesPosition, objectivesText);
		}
	}
}