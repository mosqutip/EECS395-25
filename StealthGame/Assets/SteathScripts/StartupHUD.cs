using UnityEngine;
using System.Collections;

public class StartupHUD : MonoBehaviour {
	
	float start;
	public string[] notes;
	// Use this for initialization
	void Start () 
	{
		start = Time.time;
	}
	
	void OnGUI () 
	{
		if (Time.time >= start + 5f) 
		{
			enabled = false;
		}
		else 
		{
			for(int x=0; x<notes.Length; x++)
			{
				GUI.Label(new Rect(10,20*x+10,200,20), notes[x]);
			}
		}
	}
}
