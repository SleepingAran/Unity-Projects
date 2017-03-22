using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text scoreText;
    [SerializeField] private PopupController popup;

    private int score = 0;
    // Use this for initialization
    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
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
}
