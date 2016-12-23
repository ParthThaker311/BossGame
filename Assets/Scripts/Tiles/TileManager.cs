using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {
	int levelLength;
	int levelWidth;
	private int[,] floor;
	public GameObject tile;
	public GameObject wall;
	int tileSize;
	// Use this for initialization
	void Start () {
		levelLength = Level.length;
		levelWidth = Level.width;
		tileSize = Level.tileSize;
		floor = new int[levelWidth, levelLength];
		GenerateTiles ();
		CreateTiles ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GenerateTiles(){
		for (int i = 0; i < levelWidth; i++) {
			for (int j = 0; j < levelLength; j++) {
				if (i == 0 || j == 0 || i == 9 || j == 9) {
					floor [i, j] = 1;
				} else {
					floor [i, j] = 0;
				}
			}
		}
		floor [2, 8] = 1;
		floor [3, 3] = 1;
	}
	void CreateTiles(){
		for (int i = 0; i < levelWidth; i++) {
			for (int j = 0; j < levelLength; j++) {
				if (floor [i, j] == 0) {
					GameObject obj = Instantiate (tile, new Vector3 (i * tileSize, .25f, j * tileSize), tile.transform.rotation) as GameObject;
					obj.transform.parent = this.gameObject.transform;
					obj.transform.name = "floor" + i.ToString () + j.ToString ();
				} else if (floor [i, j] == 1) {
					GameObject obj = Instantiate (wall, new Vector3 (i * tileSize, .25f, j * tileSize), tile.transform.rotation) as GameObject;
					obj.transform.parent = this.gameObject.transform;
					obj.transform.name = "wall" + i.ToString () + j.ToString ();
				}
			}
		}
	}
}
