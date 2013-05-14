using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
	
	private LineRenderer line;
	public Vector3 start;
	
	// Use this for initialization
	void Start () {
		line = gameObject.AddComponent<LineRenderer>();
		line.gameObject.layer = LayerMask.NameToLayer("MiniMap");
		line.SetWidth(.1f,.1f);
		start = GameObject.FindGameObjectWithTag("Objective").transform.position;
		start.y = 1;
		line.SetPosition(0, start);
	}
	
	// Update is called once per frame
	void Update ()
	{
		line.SetPosition(0, start);
		line.SetPosition(1, transform.position);
		start.y = 1;
	}
}
