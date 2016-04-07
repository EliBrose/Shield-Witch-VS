using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
	}
   
}
