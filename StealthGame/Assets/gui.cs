using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour
{
	void Start()
	{	
	}
	
	void Update()
	{
	}
	
	void OnGUI()
	{
		transform.Translate(0, 0, 0);
		if (GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2 - 15, 100, 30), "Retry"))
		{
			string temp = GameObject.Find("CurrentLevel").GetComponent<CurrentLevel>().current;
			Destroy(GameObject.Find("CurrentLevel"));
			Application.LoadLevel(temp);
		}
	}
}
