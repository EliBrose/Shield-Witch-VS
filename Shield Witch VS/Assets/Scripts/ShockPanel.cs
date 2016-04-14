using UnityEngine;
using System.Collections;

public class ShockPanel : MonoBehaviour {
	public DoorTrigger[] doorTriggers;
	public bool sticky;
	private bool down;
	private Animator animator;

	//Audio
	private AudioSource[] allAudioSources;
	private AudioSource elecswitchSource;

	public AudioClip elecswitch;

	// Use this for initialization
void Start () {
	animator = GetComponent<Animator> ();
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		elecswitchSource = allAudioSources [0];
}

// Update is called once per frame
void Update () {

}

void OnTriggerEnter2D(Collider2D target){
	if (target.gameObject.tag == "ShieldPulse"){
		Debug.Log ("Hit by shield pulse");
		animator.SetInteger ("AnimState", 1);
		down = true;
		elecswitchSource.clip = elecswitch;
		elecswitchSource.Play ();

		foreach (DoorTrigger trigger in doorTriggers) {
			if (trigger != null)
				trigger.Toggle (true);
		}
	}
} 

/*void OnTriggerExit2D(Collider2D target){

	if (sticky && down)
		return;

	animator.SetInteger ("AnimState", 2);

	down = false;

	foreach (DoorTrigger trigger in doorTriggers) {
		if(trigger != null)
			trigger.Toggle(false);
	}
}*/

void OnDrawGizmos(){
	Gizmos.color = sticky ? Color.red : Color.green;
	foreach (DoorTrigger trigger in doorTriggers) {
		if(trigger != null)
			Gizmos.DrawLine(transform.position, trigger.door.transform.position);
	}
}
}

