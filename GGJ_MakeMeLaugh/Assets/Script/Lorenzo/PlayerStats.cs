using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    public int maxHealth;

    public PlayerHealthBar playerHealthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        playerHealthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
