using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    private Rigidbody2D body2D;
    public GameObject player;
    private MagicShield playerShield;

    public int paceDirection = 1;
    public float speed = -10f;
    public float speedY = 0f;
    public float baseSpeed = -10f;
    public float baseSpeedY = 0f;
    public bool myBullet = false;
    public float bulletDeath = 5f;

    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        playerShield = FindObjectOfType<MagicShield>();

    }

    void Start()
    {
        StartCoroutine(DeathTime());
        //StartCoroutine(BulletMove());
        //body2D.velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        body2D.velocity = new Vector2(speed, speedY);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Bullet hit player");
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Wall")
        {
            Debug.Log("Bullet hit wall");
            Destroy(gameObject);
        }
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
        //body2D.position = col.gameObject.transform.position;
        if (col.gameObject.tag == "MagicShield")
        {
            body2D.position = new Vector2(col.gameObject.transform.position.x + .2f, col.gameObject.transform.position.y - .1f);
        }
    } */

    void OnTriggerStay2D(Collider2D col)
    {
        //Destroy(gameObject);
        if (col.gameObject.tag == "MagicShield")
        {
            if (Input.GetButton("Fire3"))
            {

                if (Input.GetAxisRaw("RightJoyVertical") > .8)
                {
                    speedY = 7.5f;
                }
                else if (Input.GetAxisRaw("RightJoyVertical") < -.7)
                {
                    speedY = -7.5f;
                }

                if (Input.GetAxisRaw("RightJoyHorizontal") < 0)
                {
                    speed = -15;
                }
                else if (Input.GetAxisRaw("RightJoyHorizontal") >= 0)
                {
                    speed = 15;
                }

                body2D.velocity = new Vector2(speed * Input.GetAxisRaw("RightJoyHorizontal"), speed * Input.GetAxisRaw("RightJoyVertical"));
                //body2D.velocity = new Vector2(speed, speedY);
                myBullet = true;
                bulletDeath = 1.5f;
                StartCoroutine(DeathTime());
            }
            else
            {
                speed = -.1f;
                speedY = 0f;
                if (Input.GetAxisRaw("RightJoyHorizontal") >= 0)
                {
                    body2D.position = new Vector2(col.gameObject.transform.position.x + .3f, col.gameObject.transform.position.y - .3f);
                }
                else if (Input.GetAxisRaw("RightJoyHorizontal") < 0)
                {
                    body2D.position = new Vector2(col.gameObject.transform.position.x - .15f, col.gameObject.transform.position.y - .3f);
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
            speed = baseSpeed;
            speedY = baseSpeedY;
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
            speed = baseSpeed;
            speedY = baseSpeedY;
        }
    }

    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(bulletDeath);
        Destroy(gameObject);
    }

}
