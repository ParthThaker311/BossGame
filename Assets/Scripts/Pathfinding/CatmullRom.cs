using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CatmullRom : MonoBehaviour {

	public int NumberOfPoints;
	public Vector3[] controlPoints;

	double time = 0;
	float DT = 0.01f;
	float speed = .005f;
	float deltaTimeX;
	float deltaTimeZ;

	int segmentNum = 0;
	public bool move;
	/* Returns a point on a cubic Catmull-Rom/Blended Parabolas curve
	 * u is a scalar value from 0 to 1
	 * segment_number indicates which 4 points to use for interpolation
	 */
	Vector3 ComputePointOnCatmullRomCurve(double u, int segmentNumber)
	{
		Vector3 point = new Vector3();

		// TODO - compute and return a point as a Vector3		
		// Hint: Points on segment number 0 start at controlPoints[0] and end at controlPoints[1]
		//		 Points on segment number 1 start at controlPoints[1] and end at controlPoints[2]
		//		 etc...
		Vector3 p0;
		if (segmentNumber - 1 < 0) {
			p0 = controlPoints[0];
		} else {
			p0 = controlPoints[(segmentNumber - 1)  % NumberOfPoints];
		}
		int segNum1 = segmentNumber;
		if (segNum1 >= NumberOfPoints) {
			segNum1 = NumberOfPoints - 1;
		}
		int segNum2 = segmentNumber + 1;
		if (segNum2 >= NumberOfPoints) {
			segNum2 = NumberOfPoints - 1;
		}
		int segNum3 = segmentNumber + 2;
		if (segNum3 >= NumberOfPoints) {
			segNum3 = NumberOfPoints - 1;
		}
		Vector3 p1 = controlPoints[segNum1];
		Vector3 p2 = controlPoints[segNum2];
		Vector3 p3 = controlPoints[segNum3];

		Vector3 a = 2f * p1;
		Vector3 b = p2 - p0;
		Vector3 c = 2f * p0 - 5f * p1 + 4f * p2 - p3;
		Vector3 d = -p0 + 3f * p1 - 3f * p2 + p3;

		point.x = (float)(0.5f * (a.x + (b.x * u) + (c.x * u * u) + (d.x * u * u * u)));
		point.y = (float)(0.5f * (a.y + (b.y * u) + (c.y * u * u) + (d.y * u * u * u)));
		point.z = (float)(0.5f * (a.z + (b.z * u) + (c.z * u * u) + (d.z * u * u * u)));

		deltaTimeX = (float)(0.5f * (b.x + (2f * c.x * u) + (3f * d.x * u * u)));
		deltaTimeZ = (float)(0.5f * (b.z + (2f * c.z * u) + (3f * d.z * u * u)));
		return point;
	}


	// Use this for initialization
	void Start () {

	}
	public void SetPoints(List<Vector3> path){
		NumberOfPoints = path.Count;
		controlPoints = new Vector3[NumberOfPoints];
		int index = 0;
		segmentNum = 0;
		foreach (Vector3 vec in path) {
			controlPoints [index] = vec;
			index++;
		}
	}
	// Update is called once per frame
	void Update () {
		if (move) {
			time += DT;
			if (segmentNum % NumberOfPoints == 0) {
				speed += .05f / (1 / DT);
				if (speed > .05f) {
					speed = .05f;
				}
			}
			if (segmentNum % NumberOfPoints == NumberOfPoints - 1) {
				speed -= .05f / (1 / DT);
				if (speed < .005f) {
					speed = .005f;
				}
			}
			// TODO - use time to determine values for u and segment_number in this function call
			if (time > 1) {
				time = 0;
				segmentNum++;
			}
			Vector3 temp = ComputePointOnCatmullRomCurve (time, segmentNum);
			transform.LookAt (temp);
			transform.position = temp;
			DT = speed / Mathf.Sqrt ((deltaTimeX * deltaTimeX) + (deltaTimeZ * deltaTimeZ));
		}

	}
}
