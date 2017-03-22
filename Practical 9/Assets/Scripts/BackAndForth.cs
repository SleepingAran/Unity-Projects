using UnityEngine;
using System.Collections;

public class BackAndForth : MonoBehaviour {

	public float speed = 3.0f;
	public float maxZ = 16.0f;
	public float minZ = -16.0f;

	public int direction = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (0, 0, direction * speed * Time.deltaTime);

		if (transform.position.z > maxZ || transform.position.z < minZ) {
			direction = -direction;
		}
		//Debug.Log ("transform.position.z = " +transform.position.z);
	}
}
