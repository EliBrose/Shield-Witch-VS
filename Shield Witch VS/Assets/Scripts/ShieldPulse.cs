// Developed by Ananda Gupta
// info@anandagupta.com
// http://anandagupta.com

using UnityEngine;
using System.Collections;

public class ShieldPulse : MonoBehaviour
{
	public float Power = 5;
	public float Radius = 5;
	public Vector3 example ;
	public bool forceReady;





	// Use this for initialization
	void Start ()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			forceReady = true;
			Debug.Log ("ForceReady");
		}
			
	}

	// Update is called once per frame
	void FixedUpdate ()
	{

		if ((Input.GetButtonDown("Fire2")) && forceReady){ 
		Debug.Log("exlosive force");
		//replace the next line so that objPos1 = location of the player
		//Vector3 objPos1 = transform.position; //--> Doesn't work
		
		//Vector3 objPos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		//Vector3 objPos1 = new Vector3 (0,0,0);
		//	Vector3 example = new Vector3 (-11, 1, 0);
		
		AddExplosionForce(GetComponent<Rigidbody2D>(), Power * 100, example, Radius);
		}
	}

	public static void AddExplosionForce (Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
	{
		var dir = (body.transform.position - expPosition);
		float calc = 1 - (dir.magnitude / expRadius);
		if (calc <= 0) { 
			calc = 0;		
		}

		body.AddForce (dir.normalized * expForce * calc);
	}


}

