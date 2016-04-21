using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;
    private float speedY;
    public float baseSpeed = 0f;
    public float baseSpeedY = 0f;

    private bool proMove = true;
    private bool shotsFired = false;


    private GameObject bulletHolder;
    private Rigidbody2D body2D;
    private MagicShield playerShield;

    public bool myBullet = false;

    void Awake()
    {
        bulletHolder = GameObject.FindGameObjectWithTag("BulletHold");
        //bulletHolder = GameObject.Find("BulletHold");
        playerShield = FindObjectOfType<MagicShield>();
        body2D = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(Movement());

        speedY = speed / 2;
        baseSpeed = speed;
        baseSpeedY = speedY;

        transform.parent = bulletHolder.transform;
        Destroy(gameObject, 3f);

    }

    void Update () {
        if(proMove == true)
        {
            StartCoroutine(Movement());
        }
        else if (proMove == false)
        {
            StopCoroutine(Movement());
        }

        if (shotsFired == true)
        {
            StartCoroutine(MyBulletMovement());
        }  
	}

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Bullet hit player");
			Destroy (gameObject);
		}
		if (col.gameObject.tag == "Wall") {
			Debug.Log ("Bullet hit wall");
			Destroy (gameObject);
		}
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Destroy(gameObject);
        if (col.gameObject.tag == "MagicShield")
        {
            //StopCoroutine(Movement());
            proMove = false;
            if (Input.GetButton("Fire3"))
            {
                shotsFired = true;
                //StartCoroutine(MyBulletMovement());
                if (Input.GetAxisRaw("RightJoyVertical") > .8)
                {
                    speedY = 7.5f;
                    //Vector3 move = new Vector3(speed, speedY, 0);
                }
                else if (Input.GetAxisRaw("RightJoyVertical") < -.7)
                {
                    speedY = 7.5f;
                    //Vector3 move = new Vector3(speed, -speedY, 0);
                }

                if (Input.GetAxisRaw("RightJoyHorizontal") < 0)
                {
                    speed = 15;
                    //Vector3 move = new Vector3(-speed, speedY, 0);
                }
                else if (Input.GetAxisRaw("RightJoyHorizontal") >= 0)
                {
                    speed = 15;
                    //Vector3 move = new Vector3(speed, speedY, 0);
                }

                body2D.velocity = new Vector2(speed * Input.GetAxisRaw("RightJoyHorizontal"), speed * Input.GetAxisRaw("RightJoyVertical"));
                //body2D.velocity = new Vector2(speed, speedY);
                myBullet = true;
            }
            else
            {
                speed = -.1f;
                speedY = 0f;
                if (Input.GetAxisRaw("RightJoyHorizontal") >= 0)
                {
                    body2D.position = new Vector2(col.gameObject.transform.position.x + .1f, col.gameObject.transform.position.y - .1f); //.3, -.3
                }
                else if (Input.GetAxisRaw("RightJoyHorizontal") < 0)
                {
                    body2D.position = new Vector2(col.gameObject.transform.position.x - .1f, col.gameObject.transform.position.y - .1f);//.15, -.3
                }
                //body2D.position = new Vector2(col.gameObject.transform.position.x + .3f, col.gameObject.transform.position.y - .3f);
                //body2D.position.x
                StartCoroutine(WaitTime());
            }

            if (playerShield.shieldUse <= 0.1)
            {
                body2D.velocity = new Vector2(-speed * Input.GetAxisRaw("RightJoyHorizontal"), -speed * Input.GetAxisRaw("RightJoyVertical"));
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "MagicShield" && myBullet == false)
        {
            //speed = baseSpeed;
            //speedY = baseSpeedY;
            //StartCoroutine(Movement());
            proMove = true;
          
        }
        else if (col.gameObject.tag == "MagicShield" && myBullet == true)
        {
            //Nothing really happens since it happens in stay right now.
        }
    }

    IEnumerator WaitTime()
    {
        if (myBullet == false)
        {
            yield return new WaitForSeconds(playerShield.shieldUse);
            //StartCoroutine(Movement());
            proMove = true;
        }
    }

    IEnumerator Movement()
    {
        yield return new WaitForSeconds(0f);
        Vector3 move = transform.up;
        move *= Time.deltaTime * speed;
        transform.Translate(move, Space.World);
        //body2D.transform.Translate(move, Space.World);
    }

    IEnumerator MyBulletMovement()
    {
        //body2D.velocity = new Vector2(speed, speedY);
        //body2D.velocity = new Vector2(speed * Input.GetAxisRaw("RightJoyHorizontal"), speed * Input.GetAxisRaw("RightJoyVertical"));

         /*shotsFired = true;
        //StartCoroutine(MyBulletMovement());
        if (Input.GetAxisRaw("RightJoyVertical") > .8)
        {
            speedY = 7.5f;
            //Vector3 move = new Vector3(speed, speedY, 0);
        }
        else if (Input.GetAxisRaw("RightJoyVertical") < -.7)
        {
            speedY = -7.5f;
            //Vector3 move = new Vector3(speed, -speedY, 0);
        }

        if (Input.GetAxisRaw("RightJoyHorizontal") < 0)
        {
            speed = -15;
            //Vector3 move = new Vector3(-speed, speedY, 0);
        }
        else if (Input.GetAxisRaw("RightJoyHorizontal") >= 0)
        {
            speed = 15;
            //Vector3 move = new Vector3(speed, speedY, 0);
        }
        */
        //body2D.velocity = new Vector2(speed * Input.GetAxisRaw("RightJoyHorizontal"), speed * Input.GetAxisRaw("RightJoyVertical")); 
        //body2D.velocity = new Vector2(speed, speedY);
        //myBullet = true;

        yield return 0;
    }
}
