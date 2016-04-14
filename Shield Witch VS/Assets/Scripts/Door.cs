using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public const int IDLE = 0;
	public const int OPENING = 1;
	public const int OPEN = 2;
	public const int CLOSING = 3;
	public float closeDelay = .4f;
	private int state = IDLE;
	private Animator animator;

	[Header("Audio")]
	private AudioSource[] allAudioSources;
	private AudioSource opendoorSource;
	private AudioSource closedoorSource;

	public AudioClip opendoor;
	public AudioClip closedoor;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		opendoorSource = allAudioSources [0];
		closedoorSource = allAudioSources [1];
	}
	
	// Update is called once per frame
	void Update () {
	    /*if(state == 2)
        {
            animator.SetInteger("AnimState", 2);
        } */
       
	}

	void OnOpenStart(){
		state = OPENING;
		opendoorSource.clip = opendoor;
		opendoorSource.Play ();
	}

	void OnOpenEnd(){
		state = OPEN;
	}


	void OnCloseStart(){
		state = CLOSING;
		closedoorSource.clip = closedoor;
		closedoorSource.Play ();
	}
	
	void OnCloseEnd(){
		state = IDLE;
	}

	void DissableCollider2D(){
		GetComponent<Collider2D>().enabled = false;
	}

	void EnableCollider2D(){
		GetComponent<Collider2D>().enabled = true;
	}

	public void Open(){
        //animator.SetInteger ("AnimState", 1);
        StartCoroutine(OpenNow());
	}

	public void Close(){
		StartCoroutine (CloseNow ());
	}

	private IEnumerator CloseNow(){
		animator.SetInteger ("AnimState", 3);
        closedoorSource.clip = closedoor;
        closedoorSource.Play();
        yield return new WaitForSeconds(.3f);
        animator.SetInteger("AnimState", 0);
        GetComponent<BoxCollider2D>().enabled = true;
        //GetComponent<Collider2D>().enabled = true;
    }

    private IEnumerator OpenNow()
    {
        animator.SetInteger("AnimState", 1);
        opendoorSource.clip = opendoor;
        opendoorSource.Play();
        yield return new WaitForSeconds(.5f);
        GetComponent<BoxCollider2D>().enabled = false;
        animator.SetInteger("AnimState", 2);
    }
	/*
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(OpenNow());
            //GetComponent<Collider2D>().enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(CloseNow());
            //GetComponent<Collider2D>().enabled = true;
        }
    }
    */


    /*void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(OpenNow());
            //GetComponent<Collider2D>().enabled = false;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(CloseNow());
            //GetComponent<Collider2D>().enabled = true;
        }
    } */
}
