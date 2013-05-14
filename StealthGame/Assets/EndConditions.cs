using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndConditions : MonoBehaviour {
	
	public Dictionary<string, bool> objectives = new Dictionary<string, bool>();
	
	void Start()
	{
		objectives.Add("Cylinder", false);
		objectives.Add("EndSphere", false);
	}
	
	void Update()
	{
		if (objectives["Cylinder"] && objectives["EndSphere"])
		{
			Application.LoadLevel("Gameover");
		}
	}
	
    void OnTriggerEnter(Collider other)
	{
		objectives[other.gameObject.name] = true;
		gameObject.GetComponent<DrawLine>().start = GameObject.FindGameObjectWithTag("Finish").transform.position;
	}
}