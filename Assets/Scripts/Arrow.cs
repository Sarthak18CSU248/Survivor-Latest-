using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody mybody;
    public Vector3 forwardVector;
    private float lifeTimer = 2f;
    private float timer;
    private bool hitSomething = false;
    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody>();
        //mybody.velocity = forwardVector * 15f;
        //transform.rotation = Quaternion.LookRotation(mybody.velocity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //mybody.velocity = forwardVector * 15f;
        mybody.AddForce(forwardVector * 50f * Time.deltaTime, ForceMode.VelocityChange);
        /*timer += Time.deltaTime;
        if(timer >=lifeTimer)
        {
            Destroy(gameObject);
        }
        if(!hitSomething)
        {
            transform.rotation = Quaternion.LookRotation(mybody.velocity);
        }*/
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Arrow")
        {
            hitSomething = true;
            stick();
        }
    }
    void stick()
    {
        mybody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
