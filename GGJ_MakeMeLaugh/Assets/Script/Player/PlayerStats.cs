using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    public int maxHealth;
    private bool canHit = true;

    public PlayerHealthBar playerHealthBar;
    public AudioSource hit;

    private void Start()
    {
        currentHealth = maxHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if(canHit == true)
        {
            currentHealth -= damage;
            playerHealthBar.UpdateHealthBar(currentHealth, maxHealth);
            hit.Play();
            StartCoroutine(RedScreen());

            if (currentHealth == 0)
            {
                Die();
            }

            canHit = false;
            StartCoroutine("CooldownHit");
        }
    }

    IEnumerator CooldownHit()
    {
        yield return new WaitForSeconds(0.25f);

        canHit = true;
    }

    IEnumerator RedScreen()
    {
        playerHealthBar.redScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        playerHealthBar.redScreen.gameObject.SetActive(false);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
