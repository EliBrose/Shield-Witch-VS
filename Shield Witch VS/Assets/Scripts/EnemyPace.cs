using UnityEngine;
using System.Collections;

public class EnemyPace : MonoBehaviour {

	public Vector3 pointA;
	public Vector3 pointB;
	public Vector3 speed = new Vector3(3, 0, 0);

	public Vector3 moveDistance = new Vector3(7,0,0);

	public int paceDirection = -1;
	public Quaternion lookLeft = Quaternion.Euler (0,0,0);
	public Quaternion lookRight = Quaternion.Euler (0,180,0);


	void Start()
	{
		pointA = this.GetComponent<Rigidbody>().position;
		pointB = pointA + moveDistance;
	}

	void FixedUpdate()
	{
		if (GetComponent<Rigidbody>().position.x >= pointB.x && paceDirection == 1)
		{
			paceDirection = -paceDirection;
			transform.rotation = lookRight;
		}

		else if (GetComponent<Rigidbody>().position.x < pointA.x && paceDirection == -1)
		{
			paceDirection = -paceDirection;
			transform.rotation = lookRight;
		}

		this.GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (paceDirection * speed) * Time.deltaTime);
	}
}
				
