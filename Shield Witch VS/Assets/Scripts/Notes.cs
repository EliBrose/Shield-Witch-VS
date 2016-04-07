using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Notes : MonoBehaviour {

	public Image noteImage;
	public Text noteHUD;
	public bool touchingNote;

	// Use this for initialization
	void Start () {
		noteImage.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.gameObject.tag == "Player") {
			touchingNote = true;
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
			Time.timeScale = 0;
			noteHUD.text = "Press Down to Put Away";
			//Instantiate (noteImage);
			noteImage.enabled = true;
	}
		if (Time.timeScale == 0 && Input.GetKey("down")) {
			Time.timeScale = 1;
			noteHUD.text = "Press Up to Read";
			noteImage.enabled = false;
			//Destroy (noteImage);
		}
		if (touchingNote == false) {
			noteHUD.text = "";
			//Destroy (noteImage);
		}
}
}
