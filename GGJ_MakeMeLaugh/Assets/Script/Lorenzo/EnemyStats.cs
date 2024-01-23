using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    public int maxHealth;
    [SerializeField]
    public int damage;

    public GameObject happyPrefab;
    public EnemyHealthBar enemyHealthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        enemyHealthBar.UpdateHealthBar(currentHealth, maxHealth);

        if(currentHealth == 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            
            if(playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    void Die()
    {
        gameObject.gameObject.SetActive(false);
        happyPrefab.gameObject.SetActive(true);
    }
}