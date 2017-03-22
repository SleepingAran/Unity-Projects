using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	[SerializeField] private GameObject enemyPrefab;
	private GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (enemy == null) {
			enemy = Instantiate (enemyPrefab) as GameObject;
			enemy.transform.position = new Vector3 ( 0, 1, 0);

		}

	}
}
