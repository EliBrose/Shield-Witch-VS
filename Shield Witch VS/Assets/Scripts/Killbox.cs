using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Killbox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Killboxed");
            //Destroy(col.gameObject);
            SceneManager.LoadScene("_GameOver");
        }
    } 
}
