using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{	
	public Dictionary<string, int> items;
	
	void Start()
	{
		items = new Dictionary<string, int>();
	}
	
	void OnTriggerEnter(Collider obj) 
	{
		if (obj.tag == "InventoryItem")
		{
			string name = obj.GetComponent<InventoryInfo>().name;
			if (items.ContainsKey(name))
			{
				items[name]++;
			}
			else
			{
				items.Add(name, 1);
			}
			
			Destroy(obj.transform.parent.gameObject);
		}
	}
}