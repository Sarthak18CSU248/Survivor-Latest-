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
   // public Image HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        txt.text = Convert.ToString(health);
        anim = Enemy.GetComponent<Animator>();
    }

    void Update()
    {
        txt.text = Convert.ToString(health);
       
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Enemy")
        {
            Debug.Log("Hit Enemy");
            anim.SetBool("hit", true);
            if (health <= 0)
            {
                anim.SetBool("death",true);
                Invoke("PlayerDied",3f);

            }
            else
            {
                health -= 5;
               
            }
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            anim.SetBool("hit", false);
        }
    }
    void PlayerDied()
    {
        anim.enabled = false;

    }
}
