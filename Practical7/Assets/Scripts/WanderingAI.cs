using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {

	public float speed = 3.0f;
	public float obstacleDistance = 5.0f;

	private bool alive = true;

	[SerializeField] private GameObject fireballPrefab;
	private GameObject fireball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (alive){
		//move enemy forward
		transform.Translate (0, 0, speed * Time.deltaTime);

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

			if (Physics.SphereCast (ray, 0.75f, out hit)) {

				GameObject hitObj = hit.transform.gameObject;
				PlayerCharacter playerChar = hitObj.GetComponent<PlayerCharacter> ();
				if (playerChar != null) {
					//shoot player
					if (fireball == null) {
						fireball = Instantiate (fireballPrefab) as GameObject;
						fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
						fireball.transform.rotation = transform.rotation;
					}
				} 
			//Rotate enemy when almost hit wall/ obstacle
			else if (hit.distance < obstacleDistance) {
					float angle = Random.Range (-110, 110);
					transform.Rotate (0, angle, 0);
				}
			}
		}
	}

	public void SetAlive(bool newValue){
		alive = newValue;
	}
}
