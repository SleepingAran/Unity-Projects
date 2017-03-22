using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopupController : MonoBehaviour {
    [SerializeField] private Slider speedSlider;
    [SerializeField] private InputField playerName;
    public void Open()
    {
        gameObject.SetActive(true);

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
	// Use this for initialization
	void Start () {
        Close();
        float speed = PlayerPrefs.GetFloat("speed", 1f);
        speedSlider.value = speed;
        string name = PlayerPrefs.GetString("player_name", "");
        playerName.text = name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void onSpeedValue(float speed)
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED,speed);
        PlayerPrefs.SetFloat("speed", speed);
    }

    public void OnNameChange()
    {
        PlayerPrefs.SetString("player_name", playerName.text);
    }
}
