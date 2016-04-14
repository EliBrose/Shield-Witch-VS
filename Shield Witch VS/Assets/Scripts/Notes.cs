	using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Notes : MonoBehaviour {

	public Image noteImage;
	public Image noteButtonImage;
	public Text noteHUD;
	public bool touchingNote;

	[Header("Audio")]
	private AudioSource[] allAudioSources;
	private AudioSource openSource;
	private AudioSource closeSource;
	private AudioSource contactSource;
	public AudioClip openNote;
	public AudioClip closeNote;
	public AudioClip contactNote;

	// Use this for initialization
	void Start () {
		noteImage.enabled = false;
		noteButtonImage.enabled = false;
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		openSource = allAudioSources [0];
		closeSource = allAudioSources [1];
		contactSource = allAudioSources [2];
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.gameObject.name == "Player_Test") {
			touchingNote = true;
			//Touch note audio
			contactSource.clip = contactNote;
			contactSource.Play ();
			//noteButtonImage.enabled = true;
			//noteHUD.text = "Press Up to Read";

				Debug.Log ("Hit note.");
				
				//Destroy (caseHUD);
				//Destroy (jewelImage);
				//Destroy (objectiveHUD);
		} 

	}

	void OnTriggerExit2D(Collider2D col)
	{
		touchingNote = false;
	}

	// Update is called once per frame
	void Update () {
		if (touchingNote && Input.GetButtonDown ("Fire2")) {
			//Audio opening

			openSource.clip = openNote;
			openSource.Play ();
			Time.timeScale = 0;
			//noteHUD.text = "A to Close";

			//Instantiate (noteImage);
			noteImage.enabled = true;
			//noteButtonImage.enabled = true;
	}
		if (Time.timeScale == 0 && Input.GetButtonDown("Y")) {
			//Audio closing note
			Time.timeScale = 1;
			noteImage.enabled = false;
			closeSource.clip = closeNote;
			closeSource.Play ();

			//noteHUD.text = "A to Read";

			//Destroy (noteImage);
		}
		if (touchingNote == false) {
			//noteHUD.text = "";
			noteButtonImage.enabled = false;
			//Destroy (noteImage);
		}
		if (touchingNote == true) {
			//noteHUD.text = "B to Read";
			//noteImage.enabled = false;
			noteButtonImage.enabled = true;
			//Destroy (noteImage);
		}
}
}
