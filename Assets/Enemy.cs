using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp = 100f;
    public float Speed = 5f;
    public float zombieDamage = 5f;
    public float attackCoolDownTime = 2f;
    public float timer;
    public bool playerInEnemyRange;
    

    public Player player;
    public float playerGunDamage;
    public float playerGrenadeDamage;
    
    public ScanForPlayer playerPosition;
    
    
    public bool isFacingRight = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        playerGunDamage = player.gunDamage;
        playerGrenadeDamage = player.GrenadeDamage;
        playerInEnemyRange = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInEnemyRange == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
               player.Hp -= zombieDamage;
               timer = attackCoolDownTime; 
            }
            
        }
        if (playerInEnemyRange == false && timer >= 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer < 0)
            {
                timer = 0;
            }
        }

        transform.position = Vector2.MoveTowards(this.transform.position, playerPosition.getPlayerPosition, Speed * Time.deltaTime);
        
        if ((playerPosition.getPlayerPosition.x > 0 && !isFacingRight) || (playerPosition.getPlayerPosition.x < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        if (Hp <= 0)
        {
            if (player.Hp < 100 && player.Hp > 0)
            {
                player.Hp += 20;
            }

            Destroy(this.gameObject);
        }
        
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInEnemyRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInEnemyRange = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EffectArea")
        {
            Debug.Log("playerGrenadeDamage");
            Hp -= playerGrenadeDamage;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Hp -= playerGunDamage;
        }

        
        
    }
    
}
