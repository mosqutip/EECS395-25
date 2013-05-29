using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForestEndConditions : MonoBehaviour {
	
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
	
    void OnTriggerEnter(Collider obj)
	{
		if (obj.gameObject.tag == "InventoryItem" || obj.gameObject.tag == "Finish")
		{
			objectives.Remove(obj.gameObject.name);
			if (objectives.Count > 0)
			{
				gameObject.transform.GetComponent<DrawLine>().start = GameObject.Find(objectives[0]).transform.position;
			}
		}
	}
}