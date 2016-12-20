using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {
	public int floorSize = 10;
	public float tileSize = 2;
	private int[,] floor;
	public GameObject tile;
	// Use this for initialization
	void Start () {
		floor = new int[floorSize, floorSize];
		GenerateTiles ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GenerateTiles(){
		for (int i = 0; i < floorSize; i++) {
			for (int j = 0; j < floorSize; j++) {
				GameObject obj = Instantiate (tile, new Vector3 (i*tileSize, .25f, j*tileSize),tile.transform.rotation) as GameObject;
				obj.transform.parent = this.gameObject.transform;
				obj.transform.name = "tile" + i.ToString() + j.ToString ();
			}
		}
	}
}
