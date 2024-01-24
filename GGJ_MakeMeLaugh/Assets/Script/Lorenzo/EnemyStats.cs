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
    [SerializeField]
    private int knockbackForce = 10;

    public GameObject happyPrefab;
    public EnemyHealthBar enemyHealthBar;
    public Rigidbody rbEnemy;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            Vector3 direction = (transform.position - collision.transform.position).normalized;

            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }

            rbEnemy.AddForce(direction * knockbackForce);
        }
    }

    void Die()
    {
        Instantiate(happyPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}