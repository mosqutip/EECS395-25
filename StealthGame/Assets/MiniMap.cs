using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour
{
	private Vector3 pos;
	public float height;
	
	void Start ()
	{
	}
	
	void Update ()
	{
		pos = GameObject.FindGameObjectWithTag("Player").transform.position;
		Vector3 newPos = new Vector3(pos.x, height, pos.z);
		transform.position = newPos;
	}
}