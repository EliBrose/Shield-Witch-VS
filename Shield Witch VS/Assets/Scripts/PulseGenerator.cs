using UnityEngine;
using System.Collections;

public class PulseGenerator : MonoBehaviour {
	private Rigidbody2D body2D;
	public int paceDirection = 1;
	public float attackDelay = 3f;
	public GameObject pulse;
	public GameObject player;
	//public int delay = 2.0;
	// Use this for initialization
	[Header("Audio")]
	private AudioSource[] allAudioSources;
	private AudioSource pulseSource;
	public AudioClip pulsesound;


	void Start () {
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		pulseSource = allAudioSources [3];
	}

	void Awake(){
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2"))
		{
			Debug.Log ("Fire2 pressed, instantiate pulse");
			Vector3 tmpPos = transform.position;
			Debug.Log (tmpPos.z);
			tmpPos.z = 0f;
			Debug.Log (tmpPos.z);
			transform.position = tmpPos;


			//GameObject pulseClone = Instantiate (pulse, transform.position, transform.rotation) as GameObject;

			GameObject pulseClone = Instantiate (pulse, tmpPos, transform.rotation) as GameObject;
			pulseSource.clip = pulsesound;
			pulseSource.Play ();
			Object.Destroy (pulseClone, 1f);


		}

	}

	/*void OnTriggerEnter2D(Collider2D col)
	{
		//if an enemy bullet touches shield bullet destroys
		if(col.gameObject.tag == "PuzzleBlock")
		{
			Debug.Log ("Collided with shield pulse");
			Destroy(col.gameObject);
		}
	}*/
}
