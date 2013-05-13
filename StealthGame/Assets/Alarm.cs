using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour
{
	private int alarmLevel;
	public Texture alarmTexture;
	private int xSize = Screen.width, ySize = Screen.height;
	
	void Start()
	{
		alarmLevel = 0;
	}

	void Update()
	{
	
	}
	
	void OnGUI()
	{
		Rect alarmRect = new Rect(5.0f, (ySize - 37.0f), 32.0f, 32.0f);
		Rect alarmLevelRect = new Rect(40.0f, (ySize - 37.0f), 32.0f, 32.0f);
		GUI.DrawTexture(alarmRect, alarmTexture);
		GUI.Label(alarmLevelRect, alarmLevel.ToString());
	}
}