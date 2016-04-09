using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavigateStart : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            Debug.Log("load game scene");
            SceneManager.LoadScene("Level");
        }
       /* if (Input.GetKeyDown("2"))
        {
            Debug.Log("load controls");
            SceneManager.LoadScene("Controls");
        }*/
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
