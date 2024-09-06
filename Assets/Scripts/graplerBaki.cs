using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graplerBaki : MonoBehaviour
{
    Rigidbody2D rb; // Change Rigidbody to Rigidbody2D

    [SerializeField] float speed = 5f;

    float mx;
    float my;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Change to Rigidbody2D
    }

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, my).normalized * speed;
    }

}