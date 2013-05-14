using UnityEngine;
using System.Collections;



public class CurrentLevel : MonoBehaviour
{	
	public string current;

	void Start ()
	{
	}
	
	void Update ()
	{
	}
	
	void Awake ()
	{
		DontDestroyOnLoad(transform.gameObject);
		CurrentLevel temp = gameObject.GetComponent<CurrentLevel>();
		temp.current = Application.loadedLevelName;
	}
}