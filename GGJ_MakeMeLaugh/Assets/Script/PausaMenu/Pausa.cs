using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject pausaTesto;
    public bool showPause = false;
    public string nomeScenaMainMenu ="";

    void Start()
    {

    }

    void PauseGame()
    {
        pausaTesto.SetActive(true);
        Time.timeScale = 0;
        
    }
    void ResumeGame()
    {
        pausaTesto.SetActive(false);
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            showPause = !showPause;
        }
        if (Input.GetKeyDown(KeyCode.Q) && showPause == true)
        {
            SceneManager.LoadScene(nomeScenaMainMenu);
        }
        if (showPause)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
}
