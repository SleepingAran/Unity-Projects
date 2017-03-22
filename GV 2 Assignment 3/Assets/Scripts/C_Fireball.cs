using UnityEngine;
using System.Collections;

public class C_Fireball : MonoBehaviour {

	public float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ( 0, 0, speed * Time.deltaTime);
        StartCoroutine(timeToDestroy());
    }
    IEnumerator timeToDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider other){


		//Detect if Fireball hits player
		C_PlayerCharacter player = other.GetComponent<C_PlayerCharacter> ();
		if (player != null)
        {
			Debug.Log ("Player hit");
			player.Hurt(1);
           
        }
        Debug.Log("hit other object");
        Destroy(this.gameObject);
       
    }
}
