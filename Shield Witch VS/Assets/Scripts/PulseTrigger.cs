using UnityEngine;
using System.Collections;


public class PulseTrigger : MonoBehaviour {
	public bool forceReady;


	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			forceReady = true;
		}
	}

}

