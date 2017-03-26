using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class C_PlayerCharacter : MonoBehaviour {
    [SerializeField] private Text loseIndicator;
	public int health;
    //C_UIController uicontroller;
    // Use this for initialization
    private void Awake()
    {
        loseIndicator.text = "";
        
    }
    void Start () {
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	public void Hurt(int damage){

		health -= damage;
		Debug.Log("Health=" + health);
        if (health == 0)
        {
            Time.timeScale = 0;
            loseIndicator.text = "YOU LOSE!";
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
    }


}
