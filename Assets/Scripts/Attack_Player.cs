using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Player : MonoBehaviour
{
    public GameObject Player;
    private Animator anim;

     void Start()
    {
        anim = Player.GetComponent<Animator>();

    }
    /*private void OnTriggerEnter(Collision other)
      
    {
        if (other.gameObject.name == "Player")
        {
            anim.SetBool("hit", true);
            other.gameObject.GetComponent<HealthSystem>().Damage(10f);
            Debug.Log("Decrease");
        }
        /*else
        {
            anim.SetBool("hit", false);
        }*/

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player")
        {
            anim.SetBool("hit", true);
            other.gameObject.GetComponent<HealthSystem>().Damage(10f); 
            Debug.Log("Decrease");
        }
        else
        {
            anim.SetBool("hit", false);
        }
    }
}
