using UnityEngine;
using System.Collections;

public class menu_scene : MonoBehaviour {

	void OnGUI() // On the GUI
    {
        if (GUI.Button(new Rect((Screen.width/2)-20,Screen.height/3,120,30),"Start Game")) //If clicked on the button 
        {
            Application.LoadLevel(1); //Load the next scene
        }
        if (GUI.Button(new Rect((Screen.width/2)-20,(Screen.height/2)+(Screen.height/6),120,30),"Exit Game"))
        {
            Application.Quit(); //If click exit button, exit the application
        }
    }
}
