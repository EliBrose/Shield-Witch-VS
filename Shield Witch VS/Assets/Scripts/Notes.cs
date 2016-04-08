using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Notes : MonoBehaviour {

	public Image noteImage;
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
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		openSource = allAudioSources [0];
		closeSource = allAudioSources [1];
		contactSource = allAudioSources [2];
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.gameObject.tag == "Player") {
			touchingNote = true;
			//Touch note audio
			contactSource.clip = contactNote;
			contactSource.Play ();
			noteHUD.text = "Press Up to Read";

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
		if (touchingNote && Input.GetKey ("up")) {
			//Audio opening
			openSource.clip = openNote;
			openSource.Play ();
			Time.timeScale = 0;
			noteHUD.text = "Press Down to Put Away";
			//Instantiate (noteImage);
			noteImage.enabled = true;
	}
		if (Time.timeScale == 0 && Input.GetKey("down")) {
			//Audio closing note
			closeSource.clip = closeNote;
			closeSource.Play ();
			Time.timeScale = 1;
			noteHUD.text = "Press Up to Read";
			noteImage.enabled = false;
			//Destroy (noteImage);
		}
		if (touchingNote == false) {
			noteHUD.text = "";
			//Destroy (noteImage);
		}
		if (touchingNote == true) {
			noteHUD.text = "Press Up to Read";
			//Destroy (noteImage);
		}
}
}
