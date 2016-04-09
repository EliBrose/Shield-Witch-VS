using UnityEngine;
using System.Collections;

public class MagicShield : MonoBehaviour {


    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    private Vector3 startPos;
    private Vector3 playerPos;

    private Transform shield;
    private SpriteRenderer shieldRender;
    private CircleCollider2D shieldCollide;

    public GameObject player;

    public float posOffset = -1f;

    public float shieldUse = 3f;
    public float shieldCharge = 2f;

    public bool inUse;


    // Use this for initialization
    void Awake ()
    {
        shield = GetComponent<Transform>();
        shieldRender = GetComponent<SpriteRenderer>();
        shieldCollide = GetComponent<CircleCollider2D>();

        startPos = shield.position;

        //playerPos = new Vector3(player.transform.position.x + .75f, player.transform.position.y + .5f, 1);

        player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.Find("Player_Test");
    }
	
    

	// Update is called once per frame
	void Update ()
    {
        
        playerPos = new Vector3(player.transform.position.x + posOffset, player.transform.position.y + posOffset, 0);
        //allows the Right Joystick to move around the "Shield"
        //Vector3 inputDirection = Vector3.zero;
       /* inputDirection.x = Input.GetAxis("RightJoyHorizontal");
        inputDirection.y = Input.GetAxis("RightJoyVertical");

        shield.position = playerPos + inputDirection; */



     

        //shieldRender.enabled = false;
        //shieldCollide.enabled = false;
        StartCoroutine(MyCoroutine());

        //A timer attempt
        if ((Input.GetAxisRaw("RightJoyHorizontal") > 0.1 || Input.GetAxisRaw("RightJoyHorizontal") < -0.1|| 
            Input.GetAxisRaw("RightJoyVertical") > 0.1 ||Input.GetAxisRaw("RightJoyVertical") < -0.1) && shieldUse >= 0)
        {
            shieldRender.enabled = true;
            shieldCollide.enabled = true;
            inUse = true;

            shieldUse -= Time.deltaTime;
            Vector3 inputDirection = Vector3.zero;
            inputDirection.x = Input.GetAxis("RightJoyHorizontal");
            inputDirection.y = Input.GetAxis("RightJoyVertical");

            shield.position = playerPos + inputDirection;
        }           
        /*else if (shieldUse <= 0)
        {
            shieldRender.enabled = false;
            shieldCollide.enabled = false;
            StartCoroutine(MyCoroutine());
        } */
        else{
            inUse = false;
        } 

    }

    //part of the timer attempt
    IEnumerator MyCoroutine()
    {
        //yield return new WaitForSeconds(shieldUse - shieldCharge);
        if (shieldUse >= 0 && inUse == false)
        {
            shieldUse += Time.deltaTime;
            if (shieldUse > 3f)
            {
                shieldUse = 3f;
            }
            shieldRender.enabled = false;
            shieldCollide.enabled = false;
        }
        else if (shieldUse < 0)
        {
            shieldRender.enabled = false;
            shieldCollide.enabled = false;
            yield return new WaitForSeconds(shieldCharge);
            shieldUse = 3f;
        }
        
    }
}
