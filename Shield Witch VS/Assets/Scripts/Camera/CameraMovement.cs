using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;
	public float xOffset;
	public float yOffset;

    public GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        //transform.position = new Vector3(posX, posY, transform.position.z);
		transform.position = new Vector3(player.transform.position.x + xOffset, yOffset, transform.position.z);
    }
}
