using UnityEngine;
using System.Collections;

public class OverheadCamera : MonoBehaviour {
	public GameObject target;
	public int height;
	Vector3 offset;
	public float damping = 10f;

	// Use this for initialization
	void Start () {
		Vector3 angler = Vector3.forward;
		offset=Vector3.up * height + angler;
	}
	
	void Update () {
	}
	
	// Update is called once per frame
	void LateUpdate () {    
		Vector3 desiredPosition = target.transform.position + offset;
		if (!target.renderer.isVisible) {
			transform.position = desiredPosition;
			transform.LookAt(target.transform.position);
		}
	}
}
