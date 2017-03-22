using UnityEngine;
using System.Collections;

public class DayNightRotation : MonoBehaviour {
    public float rotationSpeed = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
	}
}
