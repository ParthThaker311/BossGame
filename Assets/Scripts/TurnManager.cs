
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TurnManager : MonoBehaviour {
	List<Player> playerList;
	List<Hero> heroList;
	int turn;
	bool playerTurnStarted;
	bool heroTurnStarted;
	void Start(){
		playerList = PlayerList.GetPlayerList();
		heroList = HeroList.GetHeroList();
		turn = 1;
		Debug.Log ("Starting Turn: " + turn);
	}
	void Update(){
		if (turn % 2 != 0 && !playerTurnStarted) {
			EndHeroTurn();
			playerTurnStarted = true;
			foreach (Player obj in playerList) {
				obj.BeginTurn ();
			}
		} else if(turn % 2 == 0 && !heroTurnStarted){
			EndPlayerTurn ();
			heroTurnStarted = true;
			foreach(Hero obj in heroList){
				obj.BeginTurn();
			}
		}
		if(Input.GetKeyDown (KeyCode.T)) {
			turn++;
			Debug.Log ("Starting Turn: " + turn);
		}
	}
	void EndPlayerTurn(){
		playerTurnStarted = false;
		foreach(Player obj in playerList){
			obj.EndTurn();
		}
	}
	void EndHeroTurn(){
		heroTurnStarted = false;
		foreach(Hero obj in heroList){
			obj.EndTurn();
		}
	}
}
