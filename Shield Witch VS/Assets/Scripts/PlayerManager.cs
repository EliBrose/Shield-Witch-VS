using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	int clickCount = 0;
	bool opened = false;
	bool showText = false;
	public Image masterHUD;
	public Text objectiveHUD;
	public Image jewelImage;
	public Text caseHUD;
	public Text escapeHUD;
	public AudioClip mp3Thecatsmeow;
	private AudioSource source2;

	void Awake()
	{
		source2 = GetComponent<AudioSource> ();
	}

	void Start()
	{
		StartCoroutine(HowToPlay());
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		showText = true;
		if (col.transform.gameObject.tag == "Note") {
			if (Input.GetKey ("up")) {
				Debug.Log ("Hit note.");
				caseHUD.text += "Press E to unlock.";
				//Destroy (caseHUD);
				//Destroy (jewelImage);
				//Destroy (objectiveHUD);
				opened = true;
			}

		} 

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.transform.gameObject.tag == "Exit" && clickCount == 2)

		{
			Debug.Log("Game is over!!!");
			Win();
		}
	} 


	void OnTriggerExit(Collider col)
	{
		if (col.transform.gameObject.tag == "McGuffin")
		{
			showText = false;
			if (showText == false)
			{
				caseHUD.text = " ";
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.transform.gameObject.tag == "Guard")
		{
			//Debug.Log("I am touching you");
			//Death();
		}
	}


	void Death()
	{
		SceneManager.LoadScene(3);
	}

	void Win()
	{
		SceneManager.LoadScene(2);
	}

	IEnumerator HowToPlay()
	{
		yield return new WaitForSeconds(5f);
		//Destroy (masterHUD);
		//objectiveHUD.text = "Steal the Yarn!";
	}
}
