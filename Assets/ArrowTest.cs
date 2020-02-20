using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTest : MonoBehaviour
{
    private Animator animator;
    public Transform ArrowSpawnPoint;
    public Camera cam;
    public GameObject ArrowPrefab;
    public GameObject crosshair;
    //public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            crosshair.SetActive(true);
        }
        if(Input.GetMouseButtonUp(1))
        {
            
            animator.SetBool("Shoot", true);
            Invoke("ReleaseArrow", 0.92f);
            Invoke("OnShootCompleted", 1f);
        }
    }

    void ReleaseArrow()
    {
        var go = Instantiate(ArrowPrefab, ArrowSpawnPoint);
        go.GetComponent<Arrow>().forwardVector = cam.transform.forward;
        go.transform.SetParent(null);
    }

    void OnShootCompleted()
    {
        animator.SetBool("Shoot", false);
        
    }
}
