using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class RoboTrigger : MonoBehaviour {

	public GameObject[] enemies;

	void Start (){

	}

	void OnTriggerEnter2D(Collider2D hit){

		if (hit.CompareTag("Player"))
		{
			enemies [0].AddComponent<Enemy> ();
			enemies [1].AddComponent<Enemy> ();
			Destroy (gameObject);

		}
	}
}
       
