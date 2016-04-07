
using UnityEngine;
using System.Collections;

public class PulseDestroyBullet : MonoBehaviour {

	private GameObject stunnedEnemy;

	void OnTriggerEnter2D(Collider2D col)
	{
		//if an enemy bullet touches shield bullet destroys
		if(col.gameObject.tag == "Deadly")
		{
			Debug.Log ("Bullet Collided with shield pulse");
			Destroy(col.gameObject);
		}
		/*if (col.gameObject.tag == "Enemy") {
			Debug.Log ("Enemy Collided with shield pulse");
			stunnedEnemy = col.gameObject;
			//stunnedEnemy.GetComponent<EnemyShooter> ().enabled = false;
			stunnedEnemy.GetComponent<Enemy> ().enabled = false;
			OnStun ();

		}*/



	}

	/*void OnCollisionEnter2D (Collision2D col)
	{

	}*/


	/*IEnumerator OnStun()
	{
		//Play enemy death sound and then destroy
		//chasing = false;

		yield return new WaitForSeconds(2f);   
		//stunnedEnemy.GetComponent<EnemyShooter> ().enabled = true;
		stunnedEnemy.GetComponent<Enemy> ().enabled = true;
		Destroy(this.gameObject); 
	} */
}
