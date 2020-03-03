using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public Text txt;
    private Animator anim;
    public GameObject Enemy;
    public Image HealthBar;
    
    void Start()
    {
        txt.text = Convert.ToString(health);
        anim = Enemy.GetComponent<Animator>();
    }

    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            anim.SetBool("hit", true);
            if (health <= 0)
            {
                anim.SetBool("death",true);
                FindObjectOfType<AudioManager>().Play("PDeath");
                Invoke("PlayerDied",3f);

            }
            else
            {
                other.gameObject.GetComponent<Enemy>().Enemy_health -= 5;
               
            }
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetBool("hit", false);
        }
    }
    void PlayerDied()
    {
        anim.enabled = false;

    }
}
