using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stat")]
    public float Hp = 100;
    public float speed = 5f;
    public float gunDamage = 5f;
    public float GrenadeDamage = 50f;
    
    [Header("")]
    public Rigidbody2D rb;
    public Transform gunPivotPosition;
    public Gun gun;
    
    public bool isFacingRight = true;
    public Vector2 aimDirection;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 movement = movementInput * speed;

        
        
        rb.velocity = movement;
        
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePosition - rb.position;
        
        gunPivotPosition.transform.up = aimDirection;
        
        if ((aimDirection.x > 0 && !isFacingRight) || (aimDirection.x < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        if (Input.GetMouseButtonDown(0))
        {
            gun.Fire();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("asdadsdad");
            
        }

        
        
    }
    
    
}
