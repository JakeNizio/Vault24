using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    // fields
    private GameObject mainCamera;
    CharacterController controller;
    Vector3 moveInput;
    public float moveSpeed;
    public float health;
    public Weapon weapon = null;
    public Scrap scrap;
    private Armor armor;
    public Quest quest; //this can be turned into a list to allow player to do mulitple quests
    public Animator _animator;
    public int sceneBuildIndex;
    private bool loading;
    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;

    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second when a scene has loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        mainCamera = GameObject.Find("Main Camera"); // sets the camera field
        loading = true; // sets loading bool

    }


    // Start is called before the first frame update
    void Start()
    {
        scrap = GetComponent<Scrap>(); // sets scrap field
        armor = GetComponent<Armor>(); // sets armor field
        controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    public void SetAnimation() //Movement Setup
    {
        bool isMoving = moveInput != Vector3.zero;

        _animator.SetBool("isMoving", isMoving);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // teleports character to starting position zero when loading
        if (loading)
        {
            controller.enabled = false; // disables controller
            transform.position = Vector3.zero; // resets character positon
            controller.enabled = true; // enables controller
            loading = false; // disables loading
        }
        else
        {
            // tracks mouse and rotates character towards the mouse
            mouse_pos = Input.mousePosition;
            object_pos = Camera.main.WorldToScreenPoint(transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // moves the character
            moveInput.x = Input.GetAxis("Horizontal") * moveSpeed;
            moveInput.y = Input.GetAxis("Vertical") * moveSpeed;
            controller.Move(moveInput);

            SetAnimation();//Updates Movement

            // sets the camera position to track the characters position
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -14);
        }
        
    }

    // called when the character enters a trigger
    public void OnTriggerEnter(Collider other)
    {
        // collects ammo when an ammoPickup collider is triggered
        if (other.gameObject.tag == "ammoPickup" && weapon != null)
        {
            weapon.GetComponent<Ammo>().collect(12);
            Destroy(other.gameObject);

            if (quest.isActive)
            {
                quest.goal.ItemCollected();
                if (quest.goal.IsReached())
                {
                    Debug.Log("Quest Award Awarded");
                    scrap.collect(40);
                    quest.Complete();
                }
            }

        }

        // collects scrap when a scrapPickup collider is triggered
        if (other.gameObject.tag == "scrapPickup")
        {
            scrap.collect(20);
            Destroy(other.gameObject);
        }

        // takes damage when the player triggers an enemy collider
        if (other.GetComponent<Chaser>())
        {
            health -= armor.takeDamage(other.GetComponent<Chaser>().damage); // removes health after armor reduces the impact
            print(health);
            if (health <= 0)
            {
                print("here");
                Respawn();
            }
        }
    }

    // sets the characters weapon
    public void selectWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public void SetHealth()
    {
        health = 0;
    }
    public void Respawn()
    {
        if (health <= 0)
        {
            //teleport to respawn 
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            transform.position = new Vector3(0, 0, 0);

            health = 100;
            weapon.GetComponent<Ammo>().quantity = 40;
        }
    }
}