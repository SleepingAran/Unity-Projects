using UnityEngine;
using System.Collections;

public class C_SceneController : MonoBehaviour {

	[SerializeField] private GameObject enemyPrefab;
	private GameObject enemy;
    public GameObject spawnpoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (enemy == null)
            {
                enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = spawnpoint.transform.position;
                
            }
        

	}
}
