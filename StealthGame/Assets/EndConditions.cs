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
			Destroy(GameObject.Find("CurrentLevel"));
			Application.LoadLevel(Application.loadedLevel +1);
		}
	}
	
    void OnTriggerEnter(Collider obj)
	{
		if (obj.gameObject.tag == "InventoryItem" || obj.gameObject.tag == "Finish")
		{
			objectives.Remove(obj.gameObject.name);
			if (objectives.Count > 0)
			{
				gameObject.transform.parent.GetComponent<DrawLine>().start = GameObject.Find(objectives[0]).transform.position;
			}
		}
	}
}