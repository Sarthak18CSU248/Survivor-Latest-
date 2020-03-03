using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public Enemy enemy_object;
    private HealthSystem health_Sys;
    private Vector3 movePos = Vector3.zero;
    public Camera cam;
    private FrostEffect frost;
    public float speed;
    private Vector3 moveDir = Vector3.zero,moveforward;
    private bool canrun=false,canpunch=false;
    private CharacterController characterController;
    private Animator animator;
    private bool canJump = false;
    private bool kick = false; private bool punch = false;
    public float jumpspeed = 20.0f;
    public float rotationSpeed = 30.0f;
    public float walkSpeed = 10.0f;
    public float runspeed = 10f;
    private float ElapsedTime = 0f, FixedTime = 6f;
    public float energy=0f;
    public Image HealthBar,hungerBar;
    private float dummyspeed;
    public InventoryObject inventory;
    public HungerSystem hunger;
    private HealthSystem healthsystem;
    public InventoryDisplay inventoryDisplay;
    public GameObject popup;
    public GameObject Minimap,special;
    public Image energybar;
    

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        hunger = GetComponent<HungerSystem>();
        healthsystem = GetComponent<HealthSystem>();
        frost = cam.GetComponent<FrostEffect>();
        enemy_object = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        health_Sys=GetComponent<HealthSystem>();

    }
   
    void Start()
    {
        popup.SetActive(false);
    }
   
    private void FixedUpdate()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
     {
         var obj = hit.gameObject.GetComponent<Item>();
             if(obj)
             {
                 inventoryDisplay.PopupFunction(popup);
                 if (Input.GetKeyDown(KeyCode.E))
                 {
                     inventory.AddItem(obj.item, 1);
                     Destroy(obj.gameObject);
                    inventoryDisplay.popclosefunction(popup);
                 }
             }
         else if(!obj)
         {
            inventoryDisplay.popclosefunction(popup);
         }
     }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
    public void Spawn(GameObject obj)
    {
        var go = Instantiate(obj as GameObject);
        var spawnpoint=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().localPosition+(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().forward * 10);
        spawnpoint.y += 1000;
        var ray = new Ray(spawnpoint, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            spawnpoint.y = hit.point.y + go.transform.localScale.y * 0.5f;
        }
        go.transform.position = spawnpoint;

    }
    void Update()
    {

        energy = Mathf.Clamp(energy, 0, 100);
        energybar.fillAmount = (energy / 100);
        if (ElapsedTime > FixedTime)
        {
            ElapsedTime = 0f;
            energy += 10f;    
        }
        else
        {
           
            ElapsedTime += Time.deltaTime;
        }
        if(energy >=50f)
        {
            punch = true;
            special.SetActive(true);
        }
        else
        {
            punch = false;
            special.SetActive(false);

        }

        hunger.Hunger = Mathf.Clamp(hunger.Hunger, 0, 100);
        hungerBar.fillAmount = hunger.Hunger / 100;

        healthsystem.Health = Mathf.Clamp(healthsystem.Health, 0, 100);
        HealthBar.fillAmount = healthsystem.Health / 100;

        healthsystem.Health = healthsystem.Player_Hunger(healthsystem.Health);
        speed = walkSpeed;
        canrun = false;
        canJump = false;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed =runspeed;
            canrun = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            canrun = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("special", punch);
            frost.enabled = true;
            StartCoroutine(Frost());
            energy -= 25;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("special", punch);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            FindObjectOfType<AudioManager>().Play("PWalking");
        }
        if(Input.GetMouseButton(0))
        {
            kick = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            kick = false;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            punch = true;
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            punch = false;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Minimap.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.M))
        {
            Minimap.SetActive(false);
        }
       
        if (characterController.isGrounded)
        {
            moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                canJump = true;
                moveDir.y = jumpspeed;
            }
        }
        transform.Rotate(new Vector3(0, Input.GetAxisRaw("Mouse X") * rotationSpeed * Time.deltaTime, 0));
        moveDir.y -= 9.8f *Time.deltaTime;  //to make it drop
        characterController.Move(moveDir * speed * Time.deltaTime);
        var magnitude = new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;
        dummyspeed = magnitude;
        if (!canrun)
        {
            if(dummyspeed>0.5f)
            dummyspeed = 0.5f;
        }
        animator.SetFloat("speed", dummyspeed);
        animator.SetBool("Run", canrun);
        animator.SetBool("Jump", canJump);
        animator.SetBool("kick", kick);
        animator.SetBool("punch", punch);
       
        //Invoke("Special_Attack", 0f);
    }

    private IEnumerator Frost()
    {
        frost.enabled = true;
        health_Sys.enabled = false;
        yield return new WaitForSeconds(10f);
        frost.enabled = false;
        health_Sys.enabled = true;
    }
}
