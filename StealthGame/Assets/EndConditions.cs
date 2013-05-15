using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndConditions : MonoBehaviour {
	
	public List<string> objectives = new List<string>(5);
	
	void Start()
	{
		objectives.Add("Cylinder");
		objectives.Add("EndSphere");
	}
	
	void Update()
	{
		if (objectives.Count == 0)
		{
			Application.LoadLevel("Gameover");
		}
	}
	
    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "InventoryItem" || other.gameObject.tag == "Finish")
		{
			objectives.Remove(other.gameObject.name);
			if (objectives.Count > 0)
			{
				gameObject.GetComponent<DrawLine>().start = GameObject.Find(objectives[0]).transform.position;
			}
		}
	}
}