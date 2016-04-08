using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	private Rigidbody2D body2D;
	public int paceDirection = 1;
    public float speed = -10f;
    public float baseSpeed = -10f;
    public bool myBullet = false;

	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		body2D = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	void Update () {
        body2D.velocity = new Vector2(speed, 0);
		//body2D.AddForce (transform.right * speed * paceDirection);
		//this.GetComponent<Rigidbody>().AddForce (this.transform.forward * 1000);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Bullet hit player");
			Destroy (gameObject);
		}
		if (col.gameObject.tag == "Wall") {
			Debug.Log ("Bullet hit wall");
			Destroy (gameObject);
		}
	}

    /*void OnTriggerEnter2D(Collider2D col)
    {
        body2D.position = col.gameObject.transform.position;
    } */

    void OnTriggerStay2D(Collider2D col)
    {
        //Destroy(gameObject);
        if(col.gameObject.tag == "MagicShield")
        {
            //Destroy(gameObject);
            //body2D.AddForce(transform.right * -.00005f * paceDirection);
            //speed = -.1f;
            //body2D.position = new Vector2(body2D.position.x, col.gameObject.transform.position.y - .1f);
            if (Input.GetButton("Fire3"))
            {
                speed = 15;
                myBullet = true;
            } else
            {
                speed = -.1f;
                body2D.position = new Vector2(body2D.position.x, col.gameObject.transform.position.y - .1f);
            }
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if(col.gameObject.tag == "MagicShield" && myBullet == false)
        {
            speed = baseSpeed;
        }
        else if(col.gameObject.tag == "MagicShield" && myBullet == true)
        {
            //Nothing really happens since it happens in stay right now.
        }
    }
}
