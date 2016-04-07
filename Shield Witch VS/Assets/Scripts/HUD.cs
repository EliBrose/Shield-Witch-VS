using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    /*This script is INCREDIBLY basic with the way the health is displayed
    due to us lacking sprites for them. For now this will work for the Prototype*/


    //public Sprite[] Hearts;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public Text shieldTimer;

    //public Image HeartUI;


    void Start()
    {
        
    }

    void Update()
    {
        Player_Controller player = GetComponent<Player_Controller>();
        MagicShield shield = GetComponentInChildren<MagicShield>();
        if (player.curHealth == 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
        else if (player.curHealth == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
        }
        else if (player.curHealth == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }
        else if (player.curHealth == 0)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }

        shieldTimer.text = "Shield Timer " + System.Math.Round(shield.shieldUse, 0);
    }

}
