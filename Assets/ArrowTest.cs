using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTest : MonoBehaviour
{
    private Animator animator;
    public Transform ArrowSpawnPoint;
    public GameObject ArrowPrefab;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Shoot", true);
            Invoke("ReleaseArrow", 0.92f);
            Invoke("OnShootCompleted", 1f);
        }
    }

    void ReleaseArrow()
    {
        var go = Instantiate(ArrowPrefab, ArrowSpawnPoint);
        go.GetComponent<Arrow>().forwardVector = transform.forward;
        go.transform.SetParent(null);
    }

    void OnShootCompleted()
    {
        animator.SetBool("Shoot", false);
        
    }
}
