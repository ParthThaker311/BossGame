using UnityEngine;
using System.Collections;

public class Node {
	public int x;
	public int z;
	public Node previous;
	public int cost;
	public Node(int inputX, int inputZ){
		x = inputX;
		z = inputZ;
	}

}
