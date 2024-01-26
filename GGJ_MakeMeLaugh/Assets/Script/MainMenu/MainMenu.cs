using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nomeScenaGioco = "Angelo";
<<<<<<< HEAD
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject comandiMenu;
    public GameObject opzioniMenu;


=======
    public string nomeScenaComandi = "Comandi";
    public string nomeScenaCrediti = "Credits";
    public string nomeScenaMain = "AngeloMain";
>>>>>>> main

    public void NewGame()
    {
        SceneManager.LoadScene(nomeScenaGioco);
    }
    public void Comandi()
    {
<<<<<<< HEAD
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        comandiMenu.SetActive(true);
        opzioniMenu.SetActive(false);
    }
    public void Opzioni()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        comandiMenu.SetActive(false);
        opzioniMenu.SetActive(true);
    }
    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
        comandiMenu.SetActive(false);
        opzioniMenu.SetActive(false);
    }
    public void TornaAlMain() 
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        comandiMenu.SetActive(false);
        opzioniMenu.SetActive(false);
=======
        SceneManager.LoadScene(nomeScenaComandi);
    }
    public void Credits()
    {
        SceneManager.LoadScene(nomeScenaCrediti);
    }
    public void TornaAlMain() 
    {
        SceneManager.LoadScene(nomeScenaMain);
>>>>>>> main
    }
    public void Quit()
    {
        Debug.Log("Quit Game!");
        Application.Quit();

    }
}
