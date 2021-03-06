using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class FPScontroller : MonoBehaviour {

	public float speed = 0.5f;
	float gravity = -9.8f;

	CharacterController charCtrl;

	// Use this for initialization
	void Start () {
		charCtrl = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.Translate( Input.GetAxis("Horizontal") * speed , 0, Input.GetAxis("Vertical") * speed); //no collision detection

		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaY = Input.GetAxis("Vertical") * speed;

		Vector3 movement = new Vector3(deltaX, gravity, deltaY);
        movement *= Time.deltaTime;
		//charCtrl.Move(movement);
		charCtrl.Move(transform.TransformDirection(movement)); //transform from local to world coordinate system

	}
}
