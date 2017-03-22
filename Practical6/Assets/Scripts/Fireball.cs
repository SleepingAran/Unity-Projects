using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ( 0, 0, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){


		//Detect if Fireball hits player
		PlayerCharacter player = other.GetComponent<PlayerCharacter> ();
		if (player != null) {
			//Debug.Log ("Player hit");
			player.Hurt(1);
		}
		Destroy (this.gameObject);
	}
}
