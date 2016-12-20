using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour {
	Vector3 targetPos;
	bool hasMoved;
	AStar pathfind;
	CatmullRom rom;
	bool isTurn;
	int numActions = 2;
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
		if(isTurn){
			if (!hasMoved && numActions > 0 && Input.GetMouseButtonDown (0) && TileMousePos.IsValid ()) {
				hasMoved = true;
				numActions--;
				targetPos = new Vector3(TileMousePos.mousePos.x,this.transform.position.y,TileMousePos.mousePos.z);
				List<Vector3> path = pathfind.FindPath (this.transform.position, targetPos);
				rom.SetPoints (path);
				rom.move = true;
			}
			if (this.transform.position == targetPos) {
				rom.move = false;
				pathfind.Reset ();
			}
			if(numActions <=0){
				EndTurn();
			}
		}
	}
	void BeginTurn(){
		isTurn = true;	
		numActions = 2;
		hasMoved = false;
	}
	void EndTurn(){
		isTurn = false;	
	}
	public bool IsTurn(){
		return isTurn;	
	}
}
