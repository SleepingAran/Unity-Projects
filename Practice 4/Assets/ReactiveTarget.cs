using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReactToHit()
    {
        StartCoroutine(Die());

    }
     IEnumerator Die()
    {
        transform.Rotate(-75, 0, 0); //rotate
        yield return new WaitForSeconds(1.5f); //wait 1.5 second
        Destroy(this.gameObject); //disappear
    }
}
