using UnityEngine;
using System.Collections;

public class earth_gravity : MonoBehaviour {

    public Transform 太阳;
    public float forceAmountForRotation;
    private Vector3 directionOfStarFromEarth;
    private bool allowForce;
    private Rigidbody2D myRigidbody;
	// Use this for initialization
	void Start () {
        directionOfStarFromEarth = Vector3.zero;
        this.myRigidbody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        allowForce = false;
        if (Input.GetKey(KeyCode.Space))
            allowForce = true;
        directionOfStarFromEarth = transform.position - 太阳.position;
        transform.right = Vector3.Cross(directionOfStarFromEarth, Vector3.forward);

	}
    
    void FixedUpdate()
    {
        if (allowForce)
            myRigidbody.AddForce(transform.right * forceAmountForRotation);

    }
}
