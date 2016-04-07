using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Quit game");
            Application.Quit();
        }
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("Restart Game");
            SceneManager.LoadScene(1);
        }
    }
}
