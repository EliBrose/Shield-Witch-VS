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
    
    void onCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "BulletHold" || col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }
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
