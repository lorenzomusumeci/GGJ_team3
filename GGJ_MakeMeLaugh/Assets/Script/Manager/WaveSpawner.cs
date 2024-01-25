using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    public Transform enemy;
    [SerializeField, Range(4, 50)]
    private int count = 4;
    public float rate = 1f;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public Text numberWaves;
    public int currentWave = 0;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        StartCoroutine(CooldownWaves());
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if(!EnemyIsAlive())
            {
                WaveCompleted();
                StartCoroutine(CooldownWaves());
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave());

                if (count < 50)
                {
                    count += count / 4;

                    if(count > 50)
                    {
                        count = 50;
                    }
                }

                currentWave++;
                numberWaves.text = "ONDATA NUMERO " + currentWave;
                numberWaves.gameObject.SetActive(true);
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;   
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave()
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < count; i++)
        {
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    IEnumerator CooldownWaves()
    {
        numberWaves.text = "PROSSIMA ONDATA TRA 5";
        yield return new WaitForSeconds(1f);
        numberWaves.text = "PROSSIMA ONDATA TRA 4";
        yield return new WaitForSeconds(1f);
        numberWaves.text = "PROSSIMA ONDATA TRA 3";
        yield return new WaitForSeconds(1f);
        numberWaves.text = "PROSSIMA ONDATA TRA 2";
        yield return new WaitForSeconds(1f);
        numberWaves.text = "PROSSIMA ONDATA TRA 1";
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, sp.position, sp.rotation);
    }
}