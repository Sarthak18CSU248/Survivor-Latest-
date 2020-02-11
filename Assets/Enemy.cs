using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public bool enemystand,canwalk;
    private Animator animator;
    public Transform Destination;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(Destination.position);

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");
            enemystand = true;
            canwalk = true;
            animator.SetBool("standup", true);
            animator.SetBool("walk", true);

        }
    }

   
}
