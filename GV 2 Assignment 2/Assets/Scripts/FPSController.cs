using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {
    public float speed = 0.25f;
    CharacterController charCtrl;
    private float gravity = -9.8f;
    // Use this for initialization
    void Start () {
        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        /*
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaY);
        movement *= Time.deltaTime;
        Vector3 g = new Vector3(0, gravity, 0);
        charCtrl.Move(g); //constantly give a gravity downwards
        charCtrl.Move(transform.TransformDirection(movement)); //transform from local to world coordinate system
        */
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.5f;
        }
        else
        { 
        speed = 0.25f;
        }
        var deltaX = Input.GetAxis("Horizontal")*speed;
        var deltaY = Input.GetAxis("Vertical")*speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaY);
        movement = transform.TransformDirection(movement);
        Vector3 g = new Vector3(0, gravity, 0);
        charCtrl.Move(g);
        charCtrl.Move(movement);
        
        
    }
}
