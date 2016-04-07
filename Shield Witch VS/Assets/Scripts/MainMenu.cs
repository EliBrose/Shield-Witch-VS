using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Texture backgroundTexture;
    public Texture forgroundTexture;
    public float logoPlacementY;
    public float logoPlacementX;
    public float guiPlacementY1;
    public float guiPlacementY2;
    public float guiPlacementY3;
    public float guiPlacementX1;
    public float guiPlacementX2;
    public float guiPlacementX3;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
        GUI.DrawTexture(new Rect(Screen.width/4, Screen.height/6, Screen.width - Screen.width/2, Screen.height - 250), forgroundTexture);

    if(GUI.Button(new Rect(Screen.width * guiPlacementX1, Screen.height *guiPlacementY1, Screen.width* .5F, Screen.height* .1F), "Start Game"))
            {
            print("Clicked Play Game");
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5F, Screen.height * .1F), "Controls"))
                {
            print("Clicked Controls");
            Application.LoadLevel(3);
            
            }
        if (GUI.Button(new Rect(Screen.width * guiPlacementX3, Screen.height * guiPlacementY3, Screen.width * .5F, Screen.height * .1F), "Quit Game"))
        {
            print("Clicked Quit Game");
            Application.Quit();
        }

    }
}
