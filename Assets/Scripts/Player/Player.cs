using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    // For future player reference
    public static Player instance;

    public static float currentHealth;
    public static float maxHealth;
    private bool isInvincible = false;
    public float invincibleDurationSec;
    public float invincibleDeltaTime;
    public GameObject model;
    public Vector3 baseScale = new Vector3(.2f, .2f);
    public Transform startLocation;

    Rigidbody2D rb;
    Animator anim;

    private void Awake()
    {
        
    }

    void Start()
    {
        instance = this;
        setInventory();
        currentHealth = 100f;
        maxHealth = 100f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Handle movement depending on keyboard inputs
        Move(moveInput);
        toggleInventory();
        //If the player loses all health move them back to spawn
        if (currentHealth <= 0)
        {
            transform.position = startLocation.position;
            currentHealth = maxHealth;
        }

        //If the player is healed beyond full, heal down to full
        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }

    void FixedUpdate()
    {
        updatePosition();

        if (moveInput.x != 0 || moveInput.y != 0) 
        {
            //Animate player while moving
            Animate(moveInput);
        }
        else 
        {
            //If not moving set to idle
            anim.SetLayerWeight(1, 0);
        }
    }

    void SetModelScale(Vector3 scale)
    {
        model.transform.localScale = scale;
    }
}
