using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowprefab;
    public Transform arrow_spawn;
    //public float shootForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            GameObject go = Instantiate(arrowprefab, arrow_spawn);
            //GameObject go = Instantiate(arrowprefab, arrow_spawn.position, Quaternion.identity);
            //Rigidbody rb = go.GetComponent<Rigidbody>();
            //rb.velocity = cam.transform.forward * shootForce;
        }
    }
}
