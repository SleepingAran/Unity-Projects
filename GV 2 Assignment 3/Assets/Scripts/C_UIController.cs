using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class C_UIController : MonoBehaviour {

    [SerializeField] private Text scoreText;
    [SerializeField] private Text healthText;
    [SerializeField] public Text loseIndicator;
    [SerializeField] public C_PlayerCharacter playerCharacter;
    //[SerializeField] private PopupController popup;

    private int score = 5;
    public int health;
    // Use this for initialization
    void Awake()
    {
        loseIndicator.text = "";
        Messenger.AddListener(C_GameEvent.ENEMY_HIT, OnEnemyHit);
        
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(C_GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
        scoreText.text = "Enemy left: " + score.ToString();
        healthText.text = "HP: " + playerCharacter.health.ToString();

        if (score==0)
        {
            Time.timeScale = 0;
            loseIndicator.text = "YOU WIN!";
        }
       
	}


    public void OnEnemyHit()
    {
        Debug.Log("Enemy hit: " + score);
        score--;
        
    }
}
