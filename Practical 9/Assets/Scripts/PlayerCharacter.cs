using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {

	private int health;
    private const float FULL_HEALTH=10f;
	// Use this for initialization
	void Start () {
		health = (int)FULL_HEALTH;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Hurt(int damage){

		health -= damage;
		Debug.Log("Health=" + health);
        Messenger<float>.Broadcast(GameEvent.PLAYER_HIT, health / FULL_HEALTH);
	}


}
