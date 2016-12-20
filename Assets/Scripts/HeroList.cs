using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class HeroList{
    public static List<GameObject> listOfHeroes = new List<GameObject>();
    
    public static void AddToHeroes(GameObject obj){
      listOfHeroes.Add(obj);
    }
    public static void RemoveFromHeroes(GameObject obj){
      listOfHeroes.Remove(obj);
    }
    public static List<GameObject> GetHeroList(){
      return listOfHeroes;
    }
}
