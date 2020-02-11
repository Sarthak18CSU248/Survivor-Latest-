using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Transform[] destination_Position;
    private int currentIndex = 0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination_Position[currentIndex].position, speed = Time.deltaTime);
            if (Vector3.Distance(transform.position, destination_Position[currentIndex].position)<=Mathf.Epsilon)
        {
            currentIndex++;
            if (currentIndex == destination_Position.Length)
                currentIndex = 0;
        }
    }
}
