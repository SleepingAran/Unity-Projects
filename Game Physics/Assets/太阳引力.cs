using UnityEngine;
using System.Collections;

public class 太阳引力 : MonoBehaviour {

    public Transform 地球;
    public float gravitationalForce = 5;
    private Vector3 directionOfEarthFromSun;
    private Rigidbody2D myRigidbody;
	// Use this for initialization
	void Start () {
        directionOfEarthFromSun = Vector3.zero;
        this.myRigidbody = 地球.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        directionOfEarthFromSun = (transform.position - 地球.position).normalized;
        myRigidbody.AddForce(directionOfEarthFromSun * gravitationalForce);
	}
}
