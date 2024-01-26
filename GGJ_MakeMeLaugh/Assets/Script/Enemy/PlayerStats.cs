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
        yield return new WaitForSeconds(0.5f);

        canHit = true;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
