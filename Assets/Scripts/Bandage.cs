using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandage : MonoBehaviour
{
    private HealthSystem health;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        health = player.GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            health.Health += 10;
            FindObjectOfType<AudioManager>().Play("Bandage");
            Destroy(gameObject);
        }
    }
}
