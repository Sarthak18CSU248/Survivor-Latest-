using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public float Enemy_health = 100f;
    public float energy = 0f;
    public Image HealthBar;
    public Image energybar;
    public NavMeshAgent agent;
    public Transform destination;
    public GameObject Player,EnemyCanvas;
    public float healthbarYOffset = 2;
    private bool stood = false;
    public float speed = 5f;
    private float ElapsedTime = 0f, FixedTime = 5f;

    public GameObject enemy_Health;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    

    void Update()
    {
        energy = Mathf.Clamp(energy, 0, 100);
        energybar.fillAmount = (energy / 100);

        Debug.Log(energy);
       
        if (stood)
        {
            EnemyCanvas.SetActive(true);
            if (ElapsedTime > FixedTime)
            {
                ElapsedTime = 0f;
                energy += 10f;
            }
            else
            {

                ElapsedTime += Time.deltaTime;
            }
            var dist = Vector3.Distance(gameObject.transform.position, destination.position);
            
            if(dist <= 6)
            {
                agent.isStopped = true;
                animator.SetBool("attack",true);
                FindObjectOfType<AudioManager>().Play("EAttack");
            }
            else if (dist <= 20)
            {
                animator.SetBool("attack", false);
                agent.isStopped = false;
                FindObjectOfType<AudioManager>().Play("ZRun");
                agent.SetDestination(destination.position);
            }
            else
            {
                animator.SetBool("attack", false);
                agent.isStopped = true;
                FindObjectOfType<AudioManager>().Play("ZIdle");
            }
        }

        animator.SetFloat("speed", agent.velocity.magnitude);
        Enemy_health = Mathf.Clamp(Enemy_health, 0, 100);
        HealthBar.fillAmount = (Enemy_health / 100);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!stood)
            {
               
                standanim();
                enemy_Health.SetActive(true);
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
        FindObjectOfType<AudioManager>().Play("ZScream");
    }
   
}