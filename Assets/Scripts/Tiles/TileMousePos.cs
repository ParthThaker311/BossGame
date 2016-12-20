using UnityEngine;
using System.Collections;

public static class TileMousePos {
	public static Vector3 mousePos;
	public static bool valid = false;
	// Use this for initialization
	public static bool IsValid () {
		return valid;
	}
	public static void NewPosition (Vector3 pos) {
		mousePos = pos;
		valid = true;
	}
	public static void LeavePosition(){
		valid = false;
	}
}
