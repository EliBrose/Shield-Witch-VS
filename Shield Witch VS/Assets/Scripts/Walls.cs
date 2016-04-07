using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void Awake(){

	}
	// Update is called once per frame
	void Update () {

		//this.GetComponent<Rigidbody>().AddForce (this.transform.forward * 1000);
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		//if an enemy bullet touches player, health decreases and bullet destroys
		if(col.gameObject.tag == "Deadly")
		{
			Destroy(col.gameObject);
		}
	}
}
