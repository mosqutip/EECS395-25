using UnityEngine;
using System.Collections;



public class CurrentLevel : MonoBehaviour {
	
	public string current;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake () {
	//	current = Application.loadedLevelName;
		DontDestroyOnLoad(transform.gameObject);
		CurrentLevel temp = gameObject.GetComponent<CurrentLevel>();
		temp.current = Application.loadedLevelName;
		Debug.Log(gameObject.GetComponent<CurrentLevel>().current);
	}
}