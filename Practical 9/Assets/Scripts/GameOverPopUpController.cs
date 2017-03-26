using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverPopUpController : MonoBehaviour {

    public void Open()
    {
        gameObject.SetActive(true);

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start()
    {
        Close();
    }

    public void OnRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
    public void OnExit()
    {
        Application.Quit();

    }
}
