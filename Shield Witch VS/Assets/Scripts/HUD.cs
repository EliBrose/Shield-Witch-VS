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

    public GameObject noHeart1;
    public GameObject noHeart2;
    public GameObject noHeart3;

    public Text shieldTimer;

    //public Image HeartUI;


    void Start()
    {
        noHeart1.SetActive(false);
        noHeart2.SetActive(false);
        noHeart3.SetActive(false);
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


            noHeart1.SetActive(false);
            noHeart2.SetActive(false);
            noHeart3.SetActive(false);
        }
        else if (player.curHealth == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);

            noHeart1.SetActive(false);
            noHeart2.SetActive(false);
            noHeart3.SetActive(true);
        }
        else if (player.curHealth == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);

            noHeart1.SetActive(false);
            noHeart2.SetActive(true);
            noHeart3.SetActive(true);

        }
        else if (player.curHealth == 0)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);

            noHeart3.SetActive(true);
            noHeart3.SetActive(true);
            noHeart3.SetActive(true);
        }

        //shieldTimer.text = "Shield Timer " + System.Math.Round(shield.shieldUse, 0);
		/*
		//Shield audio test function
		if shield.shieldUse > 2 {
			PlayAudio(1);
		}

		else if (shield.shieldUse > 2 && shield.shieldUse < 3){
			PlayAudio(2);
		}

		else if (shield.shieldUse > 1 && shield.shieldUse < 2){
			PlayAudio(3);
		}

		else if (shield.shieldUse = 0){
			PlayAudio(4);
		}
		*/
    }
	/*
	void PlayAudio (int)
	{
		switch (int)
		{
		case 1:
			//play audio
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			//play shield break audio
			break;
		}
	}
	*/

}
