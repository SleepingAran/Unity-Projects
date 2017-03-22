using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] // check if the required component is there
public class FPSController : MonoBehaviour {
    public float speed = 100.0f;
    CharacterController charCtrl;
    private float gravity = -9.8f;

	// Use this for initialization
	void Start () {
        charCtrl = GetComponent<CharacterController>();		
	}
	
	// Update is called once per frame
	void Update () {

        float deltaX = Input.GetAxis("Horizontal")*speed;
        float deltaY = Input.GetAxis("Vertical")*speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaY);
        movement *= Time.deltaTime;
        Vector3 g = new Vector3(0, gravity, 0);
        charCtrl.Move(g); //constantly give a gravity downwards
        charCtrl.Move(transform.TransformDirection(movement)); //transform from local to world coordinate system


        /* Moving this way does not provides collision
         * transform.Translate(Input.GetAxis("Horizontal")*speed,0,Input.GetAxis("Vertical")*speed); 
         * */
	}
}
