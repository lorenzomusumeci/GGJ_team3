using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponBuyer : MonoBehaviour
{
    public string weaponName;

    private bool canBuy;
    private bool sparaRaneBuyed;

    [SerializeField]
    private int acquisto;
    [SerializeField]
    private int potenziamento = 50;

    [Header("Riferimenti")]
    public TextMeshProUGUI text;
    public CoinManager coin;
    public WeaponSwitcher weaponSwitcher;
    public AudioSource sfx;

    [Header("Balenottera")]
    public Bolla bolla;
    public Balenottera balenottera;

    [Header("SparaRane")]
    public ExplodingBullet sparaRane;

    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canBuy == true)
        {
            if(weaponName == "Balenottera")
            {
                if(coin.coin >= potenziamento)
                {
                    sfx.Play();
                    coin.coin -= potenziamento;
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
                        sfx.Play();
                        coin.coin -= acquisto;
                        weaponSwitcher.acquiredWeapon++;
                        sparaRaneBuyed = true;
                        text.text = "Upgrade 'Frogger': 100";
                    }
                }
                else
                    if(coin.coin >= potenziamento)
                    {
                        sfx.Play();
                        coin.coin -= potenziamento;
                        sparaRane.damage++;
                        sparaRane.radius = 7;
                        Destroy(gameObject);
                    } 
            }

            if(weaponName == "Seppia")
            {
                if(coin.coin >= acquisto)
                {
                    if (weaponSwitcher.acquiredWeapon == 1)
                    {
                        sfx.Play();
                        coin.coin -= acquisto;
                        weaponSwitcher.SwitchToSecondOrder(weaponSwitcher.weapons[2]);
                        weaponSwitcher.acquiredWeapon++;
                        Destroy(gameObject);
                    }
                    else
                    {
                        sfx.Play();
                        weaponSwitcher.acquiredWeapon++;
                        coin.coin -= acquisto;
                        Destroy(gameObject);
                    }
                } 
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
