using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject comandiMenu;
    public GameObject opzioniMenu;
    public GameObject highscoreMenu;

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Comandi()
    {

        mainMenu.SetActive(false);
        comandiMenu.SetActive(true);
    }

    public void Opzioni()
    {
        mainMenu.SetActive(false);
        opzioniMenu.SetActive(true);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void Highscore()
    {
        mainMenu.SetActive(false);
        highscoreMenu.SetActive(true);
    }

    public void TornaAlMain() 
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        comandiMenu.SetActive(false);
        opzioniMenu.SetActive(false);
        highscoreMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    } 
}
