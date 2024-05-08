using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class NavMeshAgent3 : MonoBehaviour
{
    [SerializeField]
    [Tooltip("巡回する地点の配列")]
    private Transform[] target;

    private NavMeshAgent navMeshAgent;
    private int targetIndex;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(target[0].position);
        animator = GetComponent<Animator>();
    }

    void Update() {

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            int rnd = Random.Range(1, 5);
            targetIndex = (targetIndex + rnd) % target.Length;
            navMeshAgent.SetDestination(target[targetIndex].position);
        }
    }
}