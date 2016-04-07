using UnityEngine;
using System.Collections;

public class PulseGenerator : MonoBehaviour {
	private Rigidbody2D body2D;
	public int paceDirection = 1;
	public float attackDelay = 3f;
	public GameObject pulse;
	public GameObject player;
	//public int delay = 2.0;
	// Use this for initialization
	void Start () {

	}

	void Awake(){
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2"))
		{
			Debug.Log ("Fire2 pressed, instantiate pulse");
			Vector3 tmpPos = transform.position;
			Debug.Log (tmpPos.z);
			tmpPos.z = 2f;
			Debug.Log (tmpPos.z);
			transform.position = tmpPos;

			//GameObject pulseClone = Instantiate (pulse, transform.position, transform.rotation) as GameObject;
			GameObject pulseClone = Instantiate (pulse, tmpPos, transform.rotation) as GameObject;
			Object.Destroy (pulseClone, .5f);


		}

	}

	/*void OnTriggerEnter2D(Collider2D col)
	{
		//if an enemy bullet touches shield bullet destroys
		if(col.gameObject.tag == "PuzzleBlock")
		{
			Debug.Log ("Collided with shield pulse");
			Destroy(col.gameObject);
		}
	}*/
}
