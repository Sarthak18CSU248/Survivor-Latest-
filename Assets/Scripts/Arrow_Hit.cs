using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Hit : MonoBehaviour
{
    public GameObject meat;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Arrow")
        {
            Destroy(gameObject,0.1f);
            meat.SetActive(true);
        }
    }
    /*private void OnTriggerEnetr(Collision collision)
    {
        if(collision.gameObject.name=="Arrow")
        {
            Debug.Log("HIt");
            Destroy(gameObject,0.1f);
            meat.SetActive(true);
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
