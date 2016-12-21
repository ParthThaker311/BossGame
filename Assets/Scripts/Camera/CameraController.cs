using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;
	int direction = 40;
	bool moving;
	Quaternion currentRot;
	Quaternion targetRot;
	Vector3 currentPos;
	Vector3 targetPos;
	public float cameraDistance = 10f;
	public float speed; 
	float oldY;
	// Use this for initialization
	void Start () {
		oldY = this.transform.position.y;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (direction == 0) {
			direction = 40;
		}
		currentRot = this.transform.rotation;
		currentPos = this.transform.position;
		if (!moving) {
			if (Input.GetKeyDown (KeyCode.Comma)) {
				targetRot = Quaternion.Euler (this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y + 90f, this.transform.rotation.eulerAngles.z);
				direction++;
				moving = true;
				UpdateRotationPosition (true);
			} else if (Input.GetKeyDown (KeyCode.Period)) {
				targetRot = Quaternion.Euler (this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y - 90f, this.transform.rotation.eulerAngles.z);
				direction--;
				moving = true;
				UpdateRotationPosition (false);
			} else {
				UpdateManualPosition ();
			}
		} else if (Mathf.Abs(currentRot.eulerAngles.y - targetRot.eulerAngles.y)>.5) {
			this.transform.rotation = Quaternion.Lerp (currentRot, targetRot, .05F);
			this.transform.position = Vector3.Lerp (currentPos, targetPos, .05F);
		} else {
			this.transform.rotation = Quaternion.Euler (20f, 45f+(90f*Mathf.Abs (direction % 4)), 0f);
			this.transform.position = targetPos;
			moving = false;
		}
		this.transform.rotation = Quaternion.Euler (20f, this.transform.rotation.eulerAngles.y, 0f);
	}
	void UpdateRotationPosition(bool increasingDir){
		switch (Mathf.Abs (direction % 4)) {
		case 0:
			if (increasingDir) {
				targetPos = new Vector3 (this.transform.position.x - cameraDistance, this.transform.position.y, this.transform.position.z);
			} else {
				targetPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - cameraDistance);
			}
			break;
		case 1:
			if(increasingDir){
				targetPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + cameraDistance);
			} else {
				targetPos = new Vector3 (this.transform.position.x-cameraDistance, this.transform.position.y, this.transform.position.z);
			}
			break;
		case 2:
			if(increasingDir){
				targetPos = new Vector3 (this.transform.position.x + cameraDistance, this.transform.position.y, this.transform.position.z);
			} else {
				targetPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + cameraDistance);
			}
			break;
		case 3:
			if(increasingDir){
				targetPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - cameraDistance);
			} else {
				targetPos = new Vector3 (this.transform.position.x+cameraDistance, this.transform.position.y, this.transform.position.z);
			}
			break;
		}
	}
	void UpdateManualPosition(){
		Vector3 newPos = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
     	this.transform.Translate(speed * newPos.normalized * Time.deltaTime);  
		this.transform.position = new Vector3 (this.transform.position.x, oldY, this.transform.position.z);
	}
}
