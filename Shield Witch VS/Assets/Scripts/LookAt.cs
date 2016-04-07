using System;
using UnityEngine;


public class LookAt : MonoBehaviour {
	public Transform target;


	void Update() {
		if (target != null) {
			transform.LookAt (target);
		}
	}
}
