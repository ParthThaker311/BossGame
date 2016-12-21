using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PlayerList{
	public static List<Player> listOfPlayers = new List<Player>();
    
	public static void AddToPlayers(Player obj){
      listOfPlayers.Add(obj);
    }
	public static void RemoveFromPlayers(Player obj){
      listOfPlayers.Remove(obj);
    }
	public static List<Player> GetPlayerList(){
      return listOfPlayers;
    }
}
