using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {

    public int speed;
    private Vector3 euler;
    private Vector3 look;
    private Transform target;
    public bool inRange;
    public GameObject bulletPrefab;
	public float shootDelay;
	public GameObject bulletSpawner;

	//Enemy Shooter Audio
	public AudioClip shooterdeath;
	private AudioSource shooterdeathSource;
	public AudioClip shooterfire;
	private AudioSource shooterfireSource;


	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
		InvokeRepeating("Shoot", 1f, shootDelay);
		//ShooterAudio
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		shooterdeathSource = allAudioSources [0];
		shooterfireSource = allAudioSources [1];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        euler = transform.eulerAngles;
        look = target.transform.position - this.transform.position;
        euler.z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = euler;

       /* if (!inRange)
        {
            //this.transform.position += look.normalized * speed * Time.deltaTime;
        }*/
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Sun")
        {
            Debug.Log("Sun Hit");
            Destroy(this.gameObject);
			StartCoroutine (OnDeath ());
        }

        if(col.gameObject.tag == "Bullet")
        {
            //target.GetComponent<Rescue>().addScoreEnemy(100);
            Destroy(this.gameObject);
        }

		/*if(col.gameObject.tag == "Player")
		{
			Debug.Log("Player in range of trigger");
			inRange = true;
		}*/

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Sun")
        {
            Debug.Log("Sun Hit");
            Destroy(this.gameObject);
            StartCoroutine(OnDeath());
        }
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player in range of trigger");
            inRange = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("Player out of range");
            inRange = false;
        }
    }
    private void Shoot() {
		
        if (!inRange)
        {
			Debug.Log ("out of range");
            return;
        }
        else
        {   
			Debug.Log ("Shooting in range");
			GameObject shot = Instantiate(bulletPrefab, bulletSpawner.transform.position, Quaternion.identity) as GameObject;
            shot.transform.eulerAngles = this.transform.eulerAngles;
			//shooterfireSource.clip = shooterfire;
			//shooterfireSource.Play ();
        }
    }

	IEnumerator OnDeath()
	{
		//Play enemy death sound and then destroy
		shooterdeathSource.clip = shooterdeath;
		shooterdeathSource.Play ();
		//inRange = false;

		yield return new WaitForSeconds(1.5f);

		Destroy(this.gameObject); 
	} 
}
