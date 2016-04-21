using UnityEngine;
using System.Collections;

public class MagicShieldBar : MonoBehaviour {


    private Animator anim;
    private MagicShield playerShield;
    private SpriteRenderer visible;

    // Use this for initialization
    void Start () {
	
	}
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerShield = FindObjectOfType<MagicShield>();
        visible = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        if(playerShield.shieldCharge >= 3) //&& playerShield.inUse == false
        {
            anim.SetInteger("Using", 0);
            visible.enabled = false;
        }

        if (playerShield.shieldCharge < 3 && playerShield.shieldCharge > 0 && playerShield.inUse == true)
        {
            anim.SetInteger("Using", 1);
            visible.enabled = true;
        } else if(playerShield.shieldCharge < 3 && playerShield.shieldCharge > 0 && playerShield.inUse == false)
        {
            anim.SetInteger("Using", 0);
            visible.enabled = false;
            //StartCoroutine(ChargeWait());
        }
       

        if(playerShield.shieldUse <= 0)
        {
            anim.SetInteger("Using", 2);
            StartCoroutine(EmptyWait());
        }


	}

    IEnumerator EmptyWait()
    {
        yield return new WaitForSeconds(2f);
        anim.SetInteger("Using", 0);
    }

    IEnumerator ChargeWait()
    {
        yield return new WaitForSeconds(playerShield.shieldCharge - 3);
        anim.SetInteger("Using", 0);
    }
}
