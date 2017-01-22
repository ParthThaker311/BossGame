using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Level {
	public static int tileSize = 2;
	public static int width = 10;
	public static int length = 10;
	public static int[,] floor = new int[width, length];
	
	public static bool IsValid(int x, int z){
		if (floor [x, z] == 0) {
			return true;
		}
		return false;
	}
}
