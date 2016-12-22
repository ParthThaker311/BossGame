using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {
	int levelLength;
	int levelWidth;
	private int[,] floor;
	public GameObject tile;
	int tileSize;
	// Use this for initialization
	void Start () {
		levelLength = Level.length;
		levelWidth = Level.width;
		tileSize = Level.tileSize;
		floor = new int[levelWidth, levelLength];
		GenerateTiles ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GenerateTiles(){
		for (int i = 0; i < levelWidth; i++) {
			for (int j = 0; j < levelLength; j++) {
					GameObject obj = Instantiate (tile, new Vector3 (i * tileSize, .25f, j * tileSize), tile.transform.rotation) as GameObject;
					obj.transform.parent = this.gameObject.transform;
					obj.transform.name = "tile" + i.ToString() + j.ToString ();
			}
		}
	}
}
