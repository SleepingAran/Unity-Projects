using UnityEngine;
using System.Collections;

public class ResetPinPosition : MonoBehaviour {
	
	
	public Vector3 _Position;
	public Quaternion _Rotation;
	
	
	// Use this for initialization
	void OnEnable () {
		_Position = gameObject.transform.position; //remember the initial position of the pin
		_Rotation = gameObject.transform.rotation; //and the initial rotation
	}


	
	// this gets called after the _ball has ratcheted up
	// so it fires on _ball = 0, not _ball = 1
	public void ResetPin(object _ball)
	{
		
		gameObject.transform.position  = _Position; //return the pin to its inital position
		gameObject.transform.rotation = _Rotation; //and its initial rotation
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; 
		gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		
	}
}
