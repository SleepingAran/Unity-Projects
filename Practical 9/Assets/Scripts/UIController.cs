using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text scoreText;
    [SerializeField] private PopupController popup;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameOverPopUpController gameOverPopup;

    private int score = 0;
    // Use this for initialization
    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger<float>.AddListener(GameEvent.PLAYER_HIT, OnPlayerHit);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger<float>.RemoveListener(GameEvent.PLAYER_HIT, OnPlayerHit);
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();
	}

    public void OnGearClicked()
    {
        Debug.Log("Gear clicked");
        popup.Open();
    }

    public void OnEnemyHit()
    {
        Debug.Log("Enemy hit: " + score);
        score++;
        
    }
    
    public void OnPlayerHit(float healthPercentage)
    {
        healthBar.transform.localScale = new Vector3(healthPercentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        if (healthPercentage <=0)
        {
            Time.timeScale = 0;
            gameOverPopup.Open();
        }
    }
}
