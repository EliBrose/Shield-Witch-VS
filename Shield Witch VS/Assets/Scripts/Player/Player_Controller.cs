using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour {

    public float maxSpeed = 10f;
    public float baseSpeed = 10f;
    public float jumpForce = 300f;
    public float baseForce = 300f;
    private bool facingRight = true;

    private Rigidbody2D body2D;
    private Animator anim;

    private bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public int curHealth;
    public int maxHealth = 3;

    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start ()
    {
        curHealth = maxHealth;
	}

	
	void FixedUpdate () {

        //uses the groundcheck transform to find whether we are ON THE GROUND. Returns true or false.
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //Using Axis to move Horizontal, should work on controller.
        float move = Input.GetAxis("Horizontal");

        //makes the animator change to the movement animation.
        anim.SetFloat("Speed", Mathf.Abs(move));

        //moves the player left or right based on button press.
        body2D.velocity = new Vector2(move * maxSpeed, body2D.velocity.y);



        if(move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
	}

    void Update()
    {
        //Currently Jump is just the space button for testing purposes, we will change this!
        if(grounded && Input.GetButtonDown("Jump"))
        {
            body2D.AddForce(new Vector2(0, jumpForce));
        }

        //Checks whether you have Health.
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if(curHealth <= 0)
        {
            Die();
        }
			
    }

    void Flip()
    {
        //acquires local scale and flipping it to make the character face properly.
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Die()
    {
        StartCoroutine(WaitFor());
        //SceneManager.LoadScene("Michael");
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        //if an enemy bullet touches player, health decreases and bullet destroys
		if (col.gameObject.tag == "Deadly")
        {
            curHealth--;
            //Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Killbox")
        {
            Die();
        }
    }
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			curHealth--;
		}
	}

    IEnumerator WaitFor()
    {
        maxSpeed = 0f;
        jumpForce = 0f;
        //play death animation
        //anim.SetBool("Death", true);
        yield return new WaitForSeconds(2f);
        body2D.transform.position = CheckPoint.GetActiveCheckPointPosition();
        curHealth = maxHealth;
        maxSpeed = baseSpeed;
        jumpForce = baseForce;
    }
}
