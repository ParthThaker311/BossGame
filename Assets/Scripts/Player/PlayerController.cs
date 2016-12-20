using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour {
	Vector3 targetPos;
	bool canAct;
	AStar pathfind;
	CatmullRom rom;
	// Use this for initialization
	void Start () {
		rom = this.gameObject.GetComponent<CatmullRom> ();
		targetPos = this.transform.position;
		canAct = true;
		pathfind = new AStar (this.transform.position.y);
		PlayerList.AddToPlayers(this);
	}
	
	// Update is called once per frame
	void Update () {
		if (canAct && Input.GetMouseButtonDown (0) && TileMousePos.IsValid ()) {
			canAct = false;
			targetPos = new Vector3(TileMousePos.mousePos.x,this.transform.position.y,TileMousePos.mousePos.z);
			List<Vector3> path = pathfind.FindPath (this.transform.position, targetPos);
			rom.SetPoints (path);
			rom.move = true;
		}
		if (this.transform.position != targetPos) {

		} else {
			rom.move = false;
			canAct = true;
			pathfind.Reset ();
		}
	}
}
