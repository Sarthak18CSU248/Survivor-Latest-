using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    //public GameObject ui;
    public NavMeshAgent agent;
    public Transform destination;
    public GameObject Player;
    //private Transform player;
    private bool stood = false;
    public float speed = 5f;
    //public bool canwalk = false;
    //spublic bool is_hit;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
       if (stood)
        {
            var dist = Vector3.Distance(gameObject.transform.position, destination.position);
            
            if(dist <= 6)
            {
                agent.isStopped = true;
                animator.SetBool("attack",true);
            }
            else if (dist <= 20)
            {
                animator.SetBool("attack", false);
                agent.isStopped = false;
                agent.SetDestination(destination.position);
            }
            else
            {
                animator.SetBool("attack", false);
                agent.isStopped = true;
            }
        }

        animator.SetFloat("speed", agent.velocity.magnitude);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!stood)
            {
                standanim();
            }
        }

    }

    void standanim()
    {
        animator.SetBool("standup", true);
        Invoke("OnStandAnimCompleted", 6.0f);
    }

    void OnStandAnimCompleted()
    {
        stood = true;
        animator.SetBool("standup", false);
    }
   
}