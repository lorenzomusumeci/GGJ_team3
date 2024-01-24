using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coin;
    public Text coinText;

    public void UpdateCoin()
    {
        coin++;
        coinText.text = coin.ToString();
    }
}