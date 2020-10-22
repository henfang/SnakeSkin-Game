using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    // For future player reference
    public static Player instance;

    Rigidbody2D rb;
    Animator anim;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Handle movement depending on keyboard inputs
        Move(moveInput);
        Animate();
    }

    void FixedUpdate()
    {
        updatePosition();
    }
}
