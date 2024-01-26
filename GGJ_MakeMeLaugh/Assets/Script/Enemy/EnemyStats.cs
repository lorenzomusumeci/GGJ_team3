using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    public int damage;
    [SerializeField]
    private int knockbackForce = 10;

    public GameObject happyPrefab;
    public EnemyHealthBar enemyHealthBar;
    public WaveSpawner waveSpawner;
    public Rigidbody rbEnemy;
    public CoinManager coinManager;

    private bool canHit = true;

    private void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
        coinManager = FindObjectOfType<CoinManager>();
        maxHealth = Mathf.Clamp(waveSpawner.currentWave / 5 + 1, 1, 5);
        currentHealth = Mathf.Clamp(maxHealth, 0, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        enemyHealthBar.UpdateHealthBar(currentHealth, maxHealth);

        if(currentHealth <= 0)
        {
            Die();
        }

        canHit = false;
        StartCoroutine("CooldownHit");
    }

    IEnumerator CooldownHit()
    {
        yield return new WaitForSeconds(0.5f);

        canHit = true;
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

    public void Die()
    {
        coinManager.UpdateCoin();
        Instantiate(happyPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}