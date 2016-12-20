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
	public float diagSpeed = 2.5f;
	float speed; 
	// Use this for initialization
	void Start () {
		speed = diagSpeed * 1.25f;

	}
	
	// Update is called once per frame
	void Update () {
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
		Debug.Log (direction);
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
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
			if (Input.GetKey (KeyCode.W)) {
				if (Input.GetKey (KeyCode.D)) {
					this.transform.position = this.transform.position + new Vector3 (diagSpeed, 0, diagSpeed);
				} else if (Input.GetKey (KeyCode.A)) {
					this.transform.position = this.transform.position +  new Vector3 (-diagSpeed, 0, diagSpeed);
				} else {
					this.transform.position = this.transform.position + new Vector3 (0, 0, speed);
				}
			} else if (Input.GetKey (KeyCode.A)) {
				if (Input.GetKey (KeyCode.W)) {
					this.transform.position = this.transform.position +  new Vector3 (-diagSpeed, 0, diagSpeed);
				} else if (Input.GetKey (KeyCode.S)) {
					this.transform.position = this.transform.position + new Vector3 (-diagSpeed, 0, -diagSpeed);
				} else {
					this.transform.position = this.transform.position + new Vector3 (-speed, 0, 0);
				}
			} else if (Input.GetKey (KeyCode.S)) {
				if (Input.GetKey (KeyCode.D)) {
					this.transform.position = this.transform.position + new Vector3 (diagSpeed, 0, -diagSpeed);
				} else if (Input.GetKey (KeyCode.A)) {
					this.transform.position = this.transform.position + new Vector3 (-diagSpeed, 0, -diagSpeed);
				} else {
					this.transform.position = this.transform.position + new Vector3 (0, 0, -speed);
				}
			} else if (Input.GetKey (KeyCode.D)) {
				if (Input.GetKey (KeyCode.W)) {
					this.transform.position = this.transform.position + new Vector3 (diagSpeed, 0, diagSpeed);
				} else if (Input.GetKey (KeyCode.S)) {
					this.transform.position = this.transform.position + new Vector3 (diagSpeed, 0, -diagSpeed);
				} else {
					this.transform.position = this.transform.position + new Vector3 (speed, 0, 0);
				}
			}
		}
	}
}
