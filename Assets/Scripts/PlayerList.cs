using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PlayerList{
    public static List<GameObject> listOfPlayers = new List<GameObject>();
    
    public static void AddToPlayers(GameObject obj){
      listOfPlayers.Add(obj);
    }
    public static void RemoveFromPlayers(GameObject obj){
      listOfPlayers.Remove(obj);
    }
    public static List<GameObject> GetPlayerList(){
      return listOfPlayers;
    }
}
