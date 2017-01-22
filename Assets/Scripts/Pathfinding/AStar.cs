using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AStar {
	List<Vector3> path = new List<Vector3> ();
	List<Node> listOfNodes = new List<Node> ();
	List<Node> visitedNodes = new List<Node>();
	Node returnedNode;
	float yPos;
	public AStar(float yPosition){
		yPos = yPosition;
	}
	public void Reset(){
		path = new List<Vector3> ();
		listOfNodes = new List<Node> ();
		visitedNodes = new List<Node>();
	}
	public List<Vector3> FindPath(Vector3 startVector,Vector3 goal){
		Node start = new Node ((int)startVector.x, (int)startVector.z);
		start.cost = cost (start, goal);
		//Debug.Log (start.cost);
		listOfNodes.Add (start);
		visitedNodes.Add (start);
		bool continueLoop = true;
		int counter = 0;
		while (listOfNodes.Count != 0 && continueLoop && counter < 10000) {
			Node element = FindLeastCostNode();
			List<Node> adjNodes = GetAdjacentNodes (element);
			foreach (Node n in adjNodes) {
				if (!Visited (n)) {
					visitedNodes.Add (n);
					n.previous = element;
					n.cost = element.cost + cost (n, goal);
					if (IsGoal (n, goal)) {
						returnedNode = n;
						continueLoop = false;
						break;
					}
					listOfNodes.Add(n);
				}
			}
			counter++;
		}

		GetPath(returnedNode, startVector);
		return path;
	}
	public void GetPath(Node n, Vector3 origin){
		if (IsGoal (n, origin)) {
			path.Add (NodeToVector3(n));
		} else {
			GetPath (n.previous, origin);
			path.Add (NodeToVector3(n));
		}
	}
	public Vector3 NodeToVector3(Node n){
		return new Vector3 (n.x, yPos, n.z);
	}
	public Node FindLeastCostNode(){
		Node leastCostNode = listOfNodes [0];
		int cost = leastCostNode.cost;
		foreach (Node n in listOfNodes) {
			if (n.cost < cost) {
				cost = n.cost;
				leastCostNode = n;
			}
		}
		listOfNodes.Remove (leastCostNode);
		return leastCostNode;
	}
	public bool IsGoal(Node n, Vector3 goal){
		if (n.x == (int)goal.x && n.z == (int)goal.z) {
			return true;
		}
		return false;
	}
	public bool Visited(Node node){
		foreach (Node n in visitedNodes) {
			if (n.x == (int)node.x && n.z == (int)node.z) {
				return true;
			}
		}
		return false;
	}

	public int cost(Node position, Vector3 goal){
		return (int)(Mathf.Abs (position.x - goal.x) + Mathf.Abs (position.z - goal.z));
	}
	public List<Node> GetAdjacentNodes (Node position){
		List<Node> returnList = new List<Node> ();
		if (position.x > 1) {
			returnList.Add (new Node (position.x -2, position.z));
		}
		if (position.x < 30) {
			returnList.Add (new Node (position.x + 2, position.z));
		}
		if (position.z > 1) {
			returnList.Add (new Node (position.x, position.z - 2));
		}
		if (position.x < 30) {
			returnList.Add (new Node (position.x, position.z + 2));
		}
		if (Random.Range (0, 100) < 50) {
			returnList.Reverse ();
		}
		return returnList;
	}
}
