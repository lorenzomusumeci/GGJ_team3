using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coin;
    public Text coinText;

    private void Update()
    {
        coinText.text = coin.ToString();
    }

    public void UpdateCoin()
    {
        coin++;
    }
}