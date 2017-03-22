﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class C_RestartGame : MonoBehaviour {

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}
