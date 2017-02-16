using UnityEngine;
using System.Collections;

public class exit_game_script : MonoBehaviour {

   
	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.Escape)) //Press escape to exit
        {
            Application.Quit();
        }
	}

   
}
