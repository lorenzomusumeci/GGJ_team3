using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HappyIA : MonoBehaviour
{
    public Transform heaven;
    private NavMeshAgent navMeshAgent;
    public Animator animator;

    void Start()
    {
        heaven = GameObject.Find("Heaven").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

        StartCoroutine(Dance());
    }

    IEnumerator Dance()
    {
        animator.Play("Dance");
        yield return new WaitForSeconds(11);
        Go();
    }

    void Go()
    {
        navMeshAgent.SetDestination(heaven.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == heaven.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
