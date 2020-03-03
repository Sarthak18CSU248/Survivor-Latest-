using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private HungerSystem hungersystem;
    private UImanager ui;
    private Player player;
    private Animator anim;
    public bool death;
    private float ElapsedTime = 0f, FixedTime = 10f;
    public int currentDay = 0;
    public float Health = 100;
    public Image image;
    private void Start()
    {
        hungersystem = GetComponent<HungerSystem>();
        anim = gameObject.GetComponent<Animator>();
        player = GetComponent<Player>();
        ui = GetComponent<UImanager>();
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
        currentDay = (((int)Time.realtimeSinceStartup / (1 * 60)) + 1);
        Debug.Log(currentDay);
        if (Health==0)
        {
            if (!death)
            {
                death = true;
                FindObjectOfType<AudioManager>().Play("PDeath");
                anim.SetTrigger("Die");
                Invoke("Animation_Stop", 2.09f);
            }
        }
        else if(currentDay == 3)
        {
            death = true;
            image.enabled=true;
            Invoke("Survived", 5f);
        }
    
    }
    public void Animation_Stop()
    {
        Debug.Log("Invoked");
        anim.enabled = false;
        player.enabled = false;
        SceneManager.LoadScene("End_Screen");
    }
    public void Survived()
    {
        SceneManager.LoadScene("End_Screen");
    }
    
}
