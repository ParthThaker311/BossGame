using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Hero : MonoBehaviour {
	Vector3 targetPos;
	bool hasMoved;
	AStar pathfind;
	CatmullRom rom;
	bool isTurn;
	int numActions = 2;
	float randVariance = 2;
	// Use this for initialization
	void Start () {
		rom = this.gameObject.GetComponent<CatmullRom> ();
		targetPos = this.transform.position;
		pathfind = new AStar (this.transform.position.y);
		HeroList.AddToHeroes(this);
	}
	
	// Update is called once per frame
	public void Update () {
		if(isTurn){
			if (!hasMoved && numActions > 0) {
				hasMoved = true;
				numActions--;
        //Move Enemy in this priority
        //1)Move to range of player if player is visible
        //2)Move to unexplored area of map 
        //3)Revisit explored areas of map
				targetPos = new Vector3(GetRandXPos(),this.transform.position.y,GetRandZPos());
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
	int GetRandXPos(){
		int newX = (int)(Random.Range(this.transform.position.x/Level.tileSize - randVariance,this.transform.position.x/Level.tileSize + randVariance + Level.tileSize))*Level.tileSize;
		while (newX < 0 || newX > (Level.width-1)*Level.tileSize) {
			newX = (int)(Random.Range(this.transform.position.x/Level.tileSize - randVariance,this.transform.position.x/Level.tileSize + randVariance + Level.tileSize))*Level.tileSize;
		}
		return newX;
	}
	int GetRandZPos(){
		int newZ = (int)(Random.Range(this.transform.position.z/Level.tileSize - randVariance,this.transform.position.z/Level.tileSize + randVariance + Level.tileSize))*Level.tileSize;
		while (newZ < 0 || newZ > (Level.length-1)*Level.tileSize) {
			newZ = (int)(Random.Range(this.transform.position.z/Level.tileSize - randVariance,this.transform.position.z/Level.tileSize + randVariance + Level.tileSize))*Level.tileSize;
		}
		return newZ;
	}
	public void BeginTurn(){
		isTurn = true;	
		numActions = 2;
		hasMoved = false;
	}
	public void EndTurn(){
		isTurn = false;	
	}
	public bool IsTurn(){
		return isTurn;	
	}
	public bool IsMoving(){
		return rom.move;
	}
}
