using UnityEngine;
using System.Collections;

/*
    Handles player
        Input
        Weapons
        Cooldowns
*/
public class Shoot : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    private GameObject bomb;

    public bool canShoot = true;
    private bool bombCD;

    public float bombCDLength = 10;
    public float shootDelay = .1f;

    public string horizontalAxis = "ShootX";
    public string verticalAxis = "ShootY";
    


    // Use this for initialization
    void Start () {
        canShoot = true;
	}
	
	// Update is called once per frame
	void Update () {

        //Vector3 shootDirection = Vector3.forward * Input.GetAxis(horizontalAxis) + Vector3.back * Input.GetAxis(verticalAxis);
        Vector2 shootDirection = new Vector2(Input.GetAxis(horizontalAxis), Input.GetAxis(verticalAxis)).normalized;
        float angleDirection = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        if (canShoot && shootDirection.sqrMagnitude > 0.0f)
        {
            Vector3 newDirection = new Vector3(0,0, angleDirection - 90);
            transform.eulerAngles = newDirection;
            Instantiate(bulletPrefab, transform.position, transform.rotation);

            canShoot = false;
            Invoke("ResetShoot", shootDelay);
        }
        
        if (Input.GetKeyDown("g") && bombCD == false)
        {
            bombCD = true;
            bomb = Instantiate(bombPrefab, this.transform.position, Quaternion.identity) as GameObject;
            StartCoroutine(CoolDown());
        }
    }

    void ResetShoot()
    {
        canShoot = true;
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(bombCDLength);
        bombCD = false;
    }

}
