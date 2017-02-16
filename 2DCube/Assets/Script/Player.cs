using UnityEngine;
using System.Collections;

[RequireComponent (typeof (DrawLine))]
public class Player : MonoBehaviour {

    float moveSpeed = 6;
    float gravity = -20;
    Vector3 velocity;
    DrawLine controller;
	// Use this for initialization
	void Start () {
        controller = GetComponent<DrawLine>();

	}
	
	void Update () {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
	}
}
