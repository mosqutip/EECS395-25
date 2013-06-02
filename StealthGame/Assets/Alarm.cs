using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour
{
	private int alarmLevel, ySize = Screen.height;
	public Texture alarmTexture;
	
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
	
	public void setAlarmLevel()
	{
		alarmLevel++;
	}
}