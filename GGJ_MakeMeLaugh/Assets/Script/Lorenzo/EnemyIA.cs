using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.position);
    }
}
