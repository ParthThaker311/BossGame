
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TurnManager : MonoBehaviour {
	List<Player> playerList;
	int turn;
	bool turnStarted;
	void Start(){
		playerList = PlayerList.GetPlayerList();
		turn = 1;
		Debug.Log ("Starting Turn: " + turn);
	}
	void Update(){
		if (turn % 2 != 0 && !turnStarted) {
			turnStarted = true;
			foreach (Player obj in playerList) {
				obj.BeginTurn ();
			}
		} else if(turn % 2 == 0){
			EndTurn ();
		}
		if(Input.GetKeyDown (KeyCode.T)) {
			turn++;
			Debug.Log ("Starting Turn: " + turn);
		}
	}
	void EndTurn(){
		turnStarted = false;
		foreach(Player obj in playerList){
			obj.EndTurn();
		}
	}
}
