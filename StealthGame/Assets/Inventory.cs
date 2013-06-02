using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{	
	private float xOffset = (Screen.width * 0.5f), yOffset = (Screen.height * 0.25f),
							screenScaleX = (Screen.width / 1024.0f), screenScaleY = (Screen.height / 768.0f);
	private bool objectiveComplete;
	private string objectiveCompletedText;
	private float clock = 0.0f, timeout = 2.0f;
	
	public Dictionary<string, int> items;
	public Texture objectiveCompletePane;
	public Texture objectiveCheck;

	void Start()
	{
		items = new Dictionary<string, int>();
		objectiveCompletedText = "Flare collected!\n";
	}
	
	void OnTriggerEnter(Collider obj)
	{
		float distance = Vector3.Distance(transform.position, obj.transform.position);
		if ((obj.tag == "InventoryItem"))
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
			objectiveComplete = true;
			Destroy(obj.transform.parent.gameObject);
		}
	}
	
	void Update()
	{
		if (objectiveComplete)
		{
			clock += Time.deltaTime;
			if (clock >= timeout)
			{
				objectiveComplete = false;
				clock = 0.0f;
			}
		}
	}
	
	void OnGUI()
	{
		if (objectiveComplete)
		{
			Rect checkPosition = new Rect(xOffset, yOffset, (100.0f * screenScaleX), (100.0f * screenScaleY));
			GUI.color = new Color(GUI.color.a, GUI.color.g, GUI.color.b, ((timeout - clock) / timeout));
			GUI.DrawTexture(checkPosition, objectiveCheck);
			Rect completedObjective = new Rect(xOffset * 0.9f, yOffset * 1.5f, (200.0f * screenScaleX), (100.0f * screenScaleY));
			GUI.Label(completedObjective, objectiveCompletedText);
		}
	}
}