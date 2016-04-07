using UnityEngine;
using System.Collections;

public class LookAhead : MonoBehaviour {

	public Transform sightStart, sightEnd;
	private bool collision = false;

	// Use this for initialization
	void Start () {

	}

	void Awake(){

	}
	// Update is called once per frame
	void Update () {
		collision = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Solid"));
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
	}
}
	//void OnCollisionEnter (Collision col){
		//Debug.Log ("Collided0");
	//	if (col.gameObject.tag == "Solid") {
			
	//		Debug.Log ("Collided");
	//		this.GetComponent<Rigidbody2D> ().velocity = new Vector3 ((GetComponent<Rigidbody2D> ().velocity.x == 1) ? -1 : 1, 1, 1);
	//	}
//	}

