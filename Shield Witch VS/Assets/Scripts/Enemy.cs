using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    private Vector3 euler;
    private Vector3 look;
    public int health = 1;
    public float speed = 1;
    public GameObject target;
    public GameObject scorePrefab;
    public bool chasing = true;
	public Collider2D OutOfRange;

    private int points = 100;

    public GameObject[] explosions;

	//Enemy Audio
	public AudioClip enemy;
	private AudioSource enemySource;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		enemySource = allAudioSources [0];
        //chasing = false;
	}

    void FixedUpdate()
    {
        if (chasing)
        {
            euler = transform.eulerAngles;
            look = target.transform.position - this.transform.position;
            this.transform.position += look.normalized * speed * Time.deltaTime;
            euler.z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = euler;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "Bomb")
		{	
            Debug.Log("Enemy destroyed by player");
			//StartCoroutine (OnDeath ());
            //target.GetComponent<Rescue>().addScoreEnemy(50);
            //OnDeath();
        }

        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("Touched Player");
            //target.GetComponent<Player>().TakeDamage(1);
           // OnDeath();
        }

    }



		
	void OnTriggerEnter2D(Collider2D col)
	{
		/*if (col.gameObject.tag == "Player")
		{
			chasing = true;
			Debug.Log ("sensed player");
		}*/

		if (col.gameObject.tag == "ShieldPulse") {
			Debug.Log ("Enemy Collided with shield pulse");
			//OnStun ();
			StartCoroutine (OnStun ());
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			//chasing = false;
			Debug.Log (" player left");
		}

	}
	IEnumerator OnStun()
	{
		//Play enemy death sound and then destroy
		//chasing = false;
		chasing = false;
		Debug.Log ("Changed chasing to false");
		yield return new WaitForSeconds(2f);  
		chasing = true;
		//stunnedEnemy.GetComponent<EnemyShooter> ().enabled = true;

		//Destroy(this.gameObject); 
	} 



	/*IEnumerator OnDeath()
	{
        GetComponent<BoxCollider2D>().enabled = false;
        GameObject explosion1 = Instantiate(explosions[Random.Range(0, 3)], transform.position, Quaternion.identity) as GameObject;
        GameObject explosion2 = Instantiate(explosions[Random.Range(0, 3)], transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion1, 1f);
        Destroy(explosion2, 1f);
        //Play enemy death sound and then destroy
        enemySource.clip = enemy;
		enemySource.Play ();
		//chasing = false;
		yield return new WaitForSeconds(.5f);       
        Destroy(this.gameObject); 
	} */
    /*public void OnDeath()
    {
        //GameObject scoreShow = Instantiate(scorePrefab, this.transform.position, Quaternion.identity) as GameObject;
        //scoreShow.transform.parent = GameObject.Find("Canvas2").transform;
        //scoreShow.GetComponent<Text>().text = "" + points;
        Destroy(this.gameObject);      
    }*/
}
