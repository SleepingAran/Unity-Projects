using UnityEngine;
using System.Collections;

public class play_sound : MonoBehaviour {
    private AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	

   void OnTriggerEnter (Collider other)
    {
        source.Play(); //plays the sound

    }
}
