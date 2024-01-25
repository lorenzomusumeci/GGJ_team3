using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponBuyer : MonoBehaviour
{
    public string weaponName;

    private bool canBuy;
    private bool sparaRaneBuyed;
    private bool seppiaBuyed;

    [SerializeField]
    private int acquisto;
    [SerializeField]
    private int potenziamento = 50;

    [Header("Riferimenti")]
    public TextMeshProUGUI text;
    public CoinManager coin;
    public WeaponSwitcher weaponSwitcher;

    [Header("Balenottera")]
    public Bolla bolla;
    public Balenottera balenottera;

    [Header("SparaRane")]
    public ExplodingBullet sparaRane;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canBuy == true)
        {
            if(weaponName == "Balenottera")
            {
                if(coin.coin >= potenziamento)
                {
                    coin.coin -= potenziamento;
                    coin.UpdateCoin();
                    bolla.damage++;
                    balenottera.fireRate = balenottera.fireRate * 2;
                    Destroy(gameObject);
                }
            }
            if(weaponName == "SparaRane")
            {
                if (sparaRaneBuyed == false)
                {
                    if(coin.coin >= acquisto)
                    {
                        coin.coin -= acquisto;
                        coin.UpdateCoin();
                        weaponSwitcher.acquiredWeapon++;
                        sparaRaneBuyed = true;
                        text.text = "Potenzia lo SparaRane a 100 monete";
                    }
                }
                else
                    if(coin.coin >= potenziamento)
                    {
                        coin.coin -= potenziamento;
                        coin.UpdateCoin();
                        sparaRane.damage++;
                        sparaRane.radius = 7;
                        Destroy(gameObject);
                    } 
            }

            if(weaponName == "Seppia")
            {
                if (weaponSwitcher.acquiredWeapon == 1)
                {
                    weaponSwitcher.SwitchToSecondOrder(weaponSwitcher.weapons[2]);
                    weaponSwitcher.acquiredWeapon++;
                }
                else
                    weaponSwitcher.acquiredWeapon++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            canBuy = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
            canBuy = false;
        }
    }
}
