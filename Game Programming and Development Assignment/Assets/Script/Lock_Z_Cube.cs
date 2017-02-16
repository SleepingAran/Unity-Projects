using UnityEngine;
using System.Collections;

public class Lock_Z_Cube : MonoBehaviour {
    public bool freezeRotation;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        pos.z = 0;
        rot.x = 0;
        rot.y = 0;
        rot.z = 0;
        transform.position = pos;
	}
}
