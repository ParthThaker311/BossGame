using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class HeroList{
    public static List<Hero> listOfHeroes = new List<Hero>();

    public static void AddToHeroes(Hero obj){
    	listOfHeroes.Add(obj);
    }
    public static void RemoveFromHeroes(Hero obj){
      listOfHeroes.Remove(obj);
    }
    public static List<Hero> GetHeroList(){
      return listOfHeroes;
    }
}
