using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
	
	private LineRenderer line;
	
	// Use this for initialization
	void Start () {
		line = gameObject.AddComponent<LineRenderer>();
		line.gameObject.layer = LayerMask.NameToLayer("MiniMap");
		line.SetWidth(.1f,.1f);
		line.SetPosition(0, GameObject.FindGameObjectWithTag("Objective").transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		line.SetPosition(1, transform.position);
	}
}
