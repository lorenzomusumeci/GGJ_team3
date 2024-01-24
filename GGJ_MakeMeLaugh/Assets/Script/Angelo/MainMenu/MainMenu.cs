using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nomeScenaGioco = "Angelo";
    public string nomeScenaComandi = "Comandi";
    public string nomeScenaCrediti = "Credits";
    public string nomeScenaMain = "AngeloMain";

    public void NewGame()
    {
        SceneManager.LoadScene(nomeScenaGioco);
    }
    public void Comandi()
    {
        SceneManager.LoadScene(nomeScenaComandi);
    }
    public void Credits()
    {
        SceneManager.LoadScene(nomeScenaCrediti);
    }
    public void TornaAlMain() 
    {
        SceneManager.LoadScene(nomeScenaMain);
    }
    public void Quit()
    {
        Debug.Log("Quit Game!");
        Application.Quit();

    }
}
