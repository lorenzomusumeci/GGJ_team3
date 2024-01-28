using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MenuHS : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

}
