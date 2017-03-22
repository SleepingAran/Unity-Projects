using UnityEngine;
using System.Collections;

public class C_ReactiveTarget : MonoBehaviour {

    private C_SceneController spawnpoint;
	// Use this for initialization
	void Start () {
        spawnpoint = GetComponent<C_SceneController>();
	}
	
	// Update is called once per frame
	void Update () {

	}
		
	public void ReactToHit()
	{
		C_WanderingAI wai = GetComponent<C_WanderingAI> ();
		if(wai != null) {
			wai.SetAlive (false);
		}
		StartCoroutine(Die());
	}

	IEnumerator Die()
	{
		transform.Rotate(-75, 0, 0);
        Destroy(spawnpoint.gameObject);
        yield return new WaitForSeconds (1.5f);
		Destroy (this.gameObject);
	}


}