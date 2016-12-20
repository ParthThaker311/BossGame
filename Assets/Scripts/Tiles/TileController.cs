using UnityEngine;
using System.Collections;

public class TileController:MonoBehaviour {
	Renderer rend;
	// Use this for initialization
	void Start () {
		rend = this.gameObject.GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {


	}
	void OnMouseEnter(){
		TileMousePos.NewPosition (this.transform.position);
		rend.material.color = Color.red;
	}
	void OnMouseExit(){
		TileMousePos.LeavePosition ();
		rend.material.color = Color.white;
	}
}
