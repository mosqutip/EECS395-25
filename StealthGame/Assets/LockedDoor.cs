using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {
	
	private GameObject player;
	private Inventory playerInvetory;
	private Vector3 target;
	private bool open;
	
	void Start () {
		target =  new Vector3(transform.position.x, transform.position.y - 20f, transform.position.z);
		player = GameObject.FindGameObjectWithTag("Player");
		playerInvetory = player.GetComponent<Inventory>();
	}
	
	void Update () {
		maybeOpen();
	}
	
	void OnTriggerEnter (Collider obj) {
		if ((obj.tag == "Player") && (playerInvetory.items.ContainsKey("Key")))
		{
			open = true;
		}
	}
	
	void maybeOpen () 
	{
		if (open)
		{
			transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime/5f);
		}
	}
}
