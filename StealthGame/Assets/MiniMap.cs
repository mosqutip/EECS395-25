using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {
	public float height;
	private Vector3 pos;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pos = GameObject.FindGameObjectWithTag("Player").transform.position;
		Vector3 newPos = new Vector3(pos.x, height, pos.z);
		transform.position = newPos;
	
	}
}
