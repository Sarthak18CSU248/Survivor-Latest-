﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private HungerSystem hungersystem;
    private Player player;
    private Animator anim;
    public bool death;
    private float ElapsedTime = 0f, FixedTime = 2f;
    public float Health = 100;
    private void Start()
    {
        hungersystem = GetComponent<HungerSystem>();
        anim = gameObject.GetComponent<Animator>();
        player = GetComponent<Player>();
    }
    public float Player_Hunger(float health)
    {
        hungersystem.Hunger = Mathf.Clamp(hungersystem.Hunger, 0, 100);
        if (ElapsedTime > FixedTime)
        {
            hungersystem.Hunger += hungersystem.HungerIncreaseFactor;
            ElapsedTime = 0f;
            if (hungersystem.Hunger >= 20f)
            {
                health -= 10f;
            }
        }
        else
        {
            ElapsedTime += Time.deltaTime;
        }
        return health;
    }
    public void Damage(float damage)
    {
        Health = Health - damage;
    }
     void Update()
    {
        Debug.Log(death);
       if(Health==0)
        {
            if (!death)
            {
                death = true;
                anim.SetTrigger("Die");
                Invoke("Animation_Stop", 2.09f);
            }
        }
        
    }
    public void Animation_Stop()
    {
        Debug.Log("Invoked");
        anim.enabled = false;
        player.enabled = false;
    }
    
}
