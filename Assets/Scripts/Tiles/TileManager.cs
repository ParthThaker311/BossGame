using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {
	int levelLength;
	int levelWidth;
	public GameObject walkableTile;
	public GameObject unwalkableTile;
	int tileSize;
	// Use this for initialization
	void Start () {
		levelLength = Level.length;
		levelWidth = Level.width;
		tileSize = Level.tileSize;
		GenerateTiles ();
		CreateTiles ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GenerateTiles(){
		for (int i = 0; i < levelWidth; i++) {
			for (int j = 0; j < levelLength; j++) {
					Level.floor [i, j] = 0;
				}
			}
	}
	void CreateTiles(){
		for (int i = 0; i < levelWidth; i++) {
			for (int j = 0; j < levelLength; j++) {
				if (Level.floor [i, j] == 0) {
					GameObject obj = Instantiate (walkableTile, new Vector3 (i * tileSize, .25f, j * tileSize), walkableTile.transform.rotation) as GameObject;
					obj.transform.parent = this.gameObject.transform;
					obj.transform.name = "floor" + i.ToString () + j.ToString ();
				} else if (Level.floor [i, j] == 1) {
					GameObject obj = Instantiate (unwalkableTile, new Vector3 (i * tileSize, .25f, j * tileSize), unwalkableTile.transform.rotation) as GameObject;
					obj.transform.parent = this.gameObject.transform;
					obj.transform.name = "floor" + i.ToString () + j.ToString ();
				}
			}
		}
	}
}
