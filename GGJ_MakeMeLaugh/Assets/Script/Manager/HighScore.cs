using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;

    public WaveSpawner waveSpawner;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(score.text != waveSpawner.currentWave.ToString())
        {
            score.text = waveSpawner.currentWave.ToString();

            if(waveSpawner.currentWave > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", waveSpawner.currentWave);
                highScore.text = waveSpawner.currentWave.ToString();
            } 
        }
        
    }
}
