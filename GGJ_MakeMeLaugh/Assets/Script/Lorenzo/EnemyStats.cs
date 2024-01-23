using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    public int maxHealth;

    public EnemyHealthBar enemyHealthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    void GetDamage(int damage)
    {
        currentHealth -= damage;

        enemyHealthBar.UpdateHealthBar(currentHealth, maxHealth);

        if(currentHealth == 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        gameObject.gameObject.SetActive(false);
    }
}