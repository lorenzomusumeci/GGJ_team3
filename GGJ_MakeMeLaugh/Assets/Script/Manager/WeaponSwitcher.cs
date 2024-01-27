using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    public int selectedWeapon = 0;
    public int acquiredWeapon = 1;
    public GameObject[] weapons;
    public PlayerHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(selectedWeapon == 0)
        {
            healthBar.backgroundSprite = healthBar.balenaSprite;
        }

        if (selectedWeapon == 1)
        {
            healthBar.backgroundSprite = healthBar.ranaSprite;
        }

        if (selectedWeapon == 2)
        {
            healthBar.backgroundSprite = healthBar.seppiaSprite;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchToSecondOrder(weapons[2]);
        }

        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(acquiredWeapon == 1)
            {
                return;
            }
            if(acquiredWeapon == 2)
            {
                if (selectedWeapon >= transform.childCount - 2)
                {
                    selectedWeapon = 0;
                }
                else
                    selectedWeapon++;
            }
            if (acquiredWeapon == 3)
            {
                if (selectedWeapon >= transform.childCount - 1)
                {
                    selectedWeapon = 0;
                }
                else
                    selectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (acquiredWeapon == 1)
            {
                return;
            }
            if (acquiredWeapon == 2)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 2;
                else
                    selectedWeapon--;
            }
            if (acquiredWeapon == 3)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--;
            }
        }

        if(previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    public void SwitchToSecondOrder(GameObject gameObject)
    {
        gameObject.transform.SetSiblingIndex(1);
    }
}