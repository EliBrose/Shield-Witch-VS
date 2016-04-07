using UnityEngine;
using System.Collections;

public class AlienC : MonoBehaviour {

	public float attackDelay = 3f;
	public GameObject projectile;
	private Animator animator;
	//private Rigidbody2D myrigidbody;

	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator> ();

		if (attackDelay > 0) {
			StartCoroutine(OnAttack());
		}
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetInteger ("AnimState", 0);
	}

	IEnumerator OnAttack(){
		yield return new WaitForSeconds(attackDelay);
		Fire ();
		StartCoroutine (OnAttack ());
	}

	void Fire(){
		animator.SetInteger ("AnimState", 1);
	}

	void OnShoot(){
		if (projectile) {
			//+(transform.forward*10)
			//GameObject clone = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			GameObject clone2 = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			//myrigidbody = clone.GetComponent<Rigidbody2D> ();
			//clone.GetComponent<Rigidbody2D>().AddForce (transform.right * -500);

		}
	
	}
}
