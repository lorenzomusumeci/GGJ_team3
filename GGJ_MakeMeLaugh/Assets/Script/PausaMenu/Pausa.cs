using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject pausaTesto;
    public GameObject canvasOpzioni;
    public bool showPause = false;

    void PauseGame()
    {
        pausaTesto.SetActive(true);
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        showPause = false;
        pausaTesto.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showPause = true;

            if (showPause)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                PauseGame();
            }
        }   
    }

    public void ExitPausa()
    {
        pausaTesto.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ResumeGame();
    }

    public void VaiOpzioniDaPausa()
    {
        canvasOpzioni.SetActive(true);
        pausaTesto.SetActive(false);
    }

    public void VaiPausaDaOpzioni()
    {
        canvasOpzioni.SetActive(false);
        pausaTesto.SetActive(true);
    }

    public void VaiMainDaOpzioni()
    {
        SceneManager.LoadScene(0);
    }
}
