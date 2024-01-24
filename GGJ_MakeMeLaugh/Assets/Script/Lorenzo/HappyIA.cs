using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HappyIA : MonoBehaviour
{
    public Transform heaven;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        heaven = GameObject.Find("Heaven").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(heaven.position);
    }
}
