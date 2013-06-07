using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
    public GameObject target;
	public float y;
	public float xoffset;
	public float zoffset;
	public int startingRotation;
    //Vector3 offset;
	int currentRotation;
	int zinvert = 1;
	int xinvert = 1;
	
    void Start() {
        //offset = target.transform.position - transform.position;
		currentRotation = startingRotation;
	}
	
	void LateUpdate() {
		if (Input.GetKey("q")){
			currentRotation -= 1;
			if (currentRotation >= 360){
				currentRotation -= 360;
			}
		}
		if (Input.GetKey("e")){
			currentRotation += 1;
			if (currentRotation <= -360){
				currentRotation += 360;
			}
		}
		if ((currentRotation == startingRotation) || (currentRotation == startingRotation - 360)){
				zinvert = 1;
				xinvert = 1;
		}
		else if ((currentRotation == startingRotation + 90) || (currentRotation == startingRotation - 270)){
				zinvert = -1;
				xinvert = 1;
		}
		else if ((currentRotation == startingRotation + 180) || (currentRotation == startingRotation - 180)){
				zinvert = -1;
				xinvert = -1;
		}
		else {
				zinvert = 1;
				xinvert = -1;
		}		
					
		
	    //float desiredAngle = target.transform.eulerAngles.y;
    	//Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentRotation, transform.eulerAngles.z);
		Vector3 newPosition = new Vector3(target.transform.position.x - xoffset * xinvert, y, target.transform.position.z - zoffset * zinvert);
		transform.position = newPosition;
		//transform.LookAt(target.transform);
	}
}