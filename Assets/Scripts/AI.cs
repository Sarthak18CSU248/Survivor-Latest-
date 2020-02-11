using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform Destination;
    public GameObject Tile;
    public float x, y, z;
 
    // Start is called before the first frame update
    void Start()
    {
        
       
        Instantiate(Tile, new Vector3(x, y, z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        var navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(Destination.position);
    }
}
